using System;
using System.Net.Http;
using System.Threading.Tasks;
using ActiveCampaignSharp.Request;
using ActiveCampaignSharp.Response;
using Newtonsoft.Json;

namespace ActiveCampaignSharp
{
    /// <summary>
    /// A service to interact with the ActiveCampaign API.
    /// </summary>
    public class ActiveCampaignClient : IActiveCampaignClient
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Constructs a new <see cref="ActiveCampaignClient"/>. Should generally be an application-wide singleton to
        /// control the <see cref="HttpClient"/> lifecycle.
        /// </summary>
        /// <param name="apiToken">The ActiveCampaign API Token.</param>
        /// <param name="httpClient">The (optional) HTTP Client. If you don't provide one, one will be provided for you.</param>
        public ActiveCampaignClient(string apiToken, string apiUrl, HttpClient httpClient = null)
        {
            if (string.IsNullOrEmpty(apiToken))
            {
                throw new ActiveCampaignException("Please specify a valid Api Token to proceed.");
            }

            // either use the passed in HttpClient or construct our own.
            _httpClient = httpClient ?? new HttpClient();

            // All requests on this HTTP Client need to include the Api-Token request header for authentication.
            _httpClient.DefaultRequestHeaders.Add("Api-Token", apiToken);

            if (string.IsNullOrEmpty(apiUrl))
            {
                throw new ActiveCampaignException("Please specify a valid API Url to proceed.");
            }
            else
            {
                if(!apiUrl.EndsWith("/", StringComparison.InvariantCulture))
                {
                    // ensure that the apiUrl ends with a "/" char.
                    apiUrl += "/";
                }
                var apibase = new Uri(apiUrl);
                if (!apibase.IsWellFormedOriginalString())
                {
                    throw new ActiveCampaignException("The API URL is invalid.");
                }
                _httpClient.BaseAddress = apibase;
            }
        }

        /// <summary>
        /// Allows for the invocation of otherwise non-implemented API calls. 
        /// </summary>
        /// <param name="action">The full action (i.e. campaigns/123/links) for the REST method being called.</param>
        /// <param name="method">The HTTP Verb from <see cref="HttpMethods"/></param>
        /// <param name="request">The request body (if needed). This is a dynamic.</param>
        /// <returns>An object encapsulating the result from the AC API.</returns>
        public async Task<BaseResponse> OtherRequestAsync(string action, HttpMethods method, dynamic request = null)
        {
            HttpResponseMessage response;
            switch (method)
            {
                case HttpMethods.GET:
                    response = await _httpClient.GetAsync(action);
                    break;
                case HttpMethods.DELETE:
                    response = await _httpClient.DeleteAsync(action);
                    break;
                case HttpMethods.POST:
                    response = await _httpClient.PostAsync(action, JsonConvert.SerializeObject(request));
                    break;
                case HttpMethods.PUT:
                    response = await _httpClient.PutAsync(action, JsonConvert.SerializeObject(request));
                    break;
                default:
                    throw new ActiveCampaignException("Invalid HTTP method requested");
            }

            if (response != null)
            {
                // turn the response into a valid result.
                if (!response.IsSuccessStatusCode)
                {
                    throw new ActiveCampaignException($"Request failed, status: {response.StatusCode}. Additional details: {await response.Content.ReadAsStringAsync()}");
                }

                return new BaseResponse { Result = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync()) };
            }

            throw new ActiveCampaignException("Failed to find appropriate method and action to execute.");
        }

        /// <summary>
        /// Invokes the appropriate REST method in the AC API.
        /// </summary>
        /// <typeparam name="T">The type of request to invoke.</typeparam>
        /// <param name="request">The request containing all metadata necessary to interact with the API.</param>
        /// <returns>An object encapsulating the result from the AC API.</returns>
        public async Task<BaseResponse> RequestAsync<T>(T request) where T : BaseRequest
        {
            HttpResponseMessage response;

            switch (request.Method)
            {
                case HttpMethods.GET:
                    if (request is BaseIdRequest getIdRequest)
                    {
                        response = await _httpClient.GetAsync(getIdRequest.ActionWithId);
                    }
                    else if(request is BaseRequestWithFilter filterRequest)
                    {
                        response = await _httpClient.GetAsync(filterRequest.FullAction);
                    }
                    else
                    {
                        throw new ActiveCampaignException("Attempted GET on non-implemented GET.");
                    }
                    break;
                case HttpMethods.POST:
                    response = await _httpClient.PostAsync(request.Action, new StringContent(JsonConvert.SerializeObject(request)));
                    break;
                case HttpMethods.DELETE:
                    var deleteIdRequest = request as BaseIdRequest;
                    response = await _httpClient.DeleteAsync(deleteIdRequest.ActionWithId);
                    break;
                case HttpMethods.PUT:
                    var putIdRequest = request as BaseIdRequest;
                    response = await _httpClient.PutAsync(putIdRequest.ActionWithId, new StringContent(JsonConvert.SerializeObject(request)));
                    break;
                default:
                    throw new ActiveCampaignException("Invalid HTTP method requested");
            }


            if (response != null)
            {
                // turn the response into a valid result.
                if (!response.IsSuccessStatusCode)
                {
                    throw new ActiveCampaignException($"Request failed, status: {response.StatusCode}. Additional details: {await response.Content.ReadAsStringAsync()}");
                }

                return new BaseResponse { Result = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync()) };
            }

            throw new ActiveCampaignException("Failed to find appropriate method and action to execute.");

        }


    }
}
