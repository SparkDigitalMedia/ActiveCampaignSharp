using System.Threading.Tasks;
using ActiveCampaignSharp.Request;
using ActiveCampaignSharp.Response;

namespace ActiveCampaignSharp
{
    public interface IActiveCampaignClient
    {
        Task<BaseResponse> OtherRequestAsync(string action, HttpMethods method, dynamic request = null);
        Task<BaseResponse> RequestAsync<T>(T request) where T : BaseRequest;

    }
}
