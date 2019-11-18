using System;
using System.Collections.Generic;
using System.Text;

namespace ActiveCampaignSharp.Request
{
    public abstract class BaseRequestWithFilter : BaseRequest
    {
        public Dictionary<string, string> FilterParamters { get; internal set; } = new Dictionary<string, string>();

        public string FullAction => $"{Action}{BuildQueryString()}";

        private string BuildQueryString()
        {
            var param = new List<string>();
            foreach(var f in FilterParamters)
            {
                param.Add($"{f.Key}={f.Value}");
            }

            return "?" + string.Join("&", param);

        }
    }
}
