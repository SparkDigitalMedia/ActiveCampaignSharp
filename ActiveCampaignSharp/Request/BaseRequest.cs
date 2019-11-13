using System;
using Newtonsoft.Json;
namespace ActiveCampaignSharp.Request
{
    public abstract class BaseRequest
    {
        [JsonIgnore]
        public string Action { get; internal set; }
        [JsonIgnore]
        public HttpMethods Method { get; internal set; }
    }
}
