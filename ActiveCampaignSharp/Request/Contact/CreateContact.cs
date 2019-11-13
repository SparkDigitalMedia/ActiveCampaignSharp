using System;
using Newtonsoft.Json;

namespace ActiveCampaignSharp.Request.Contact
{
    public class CreateContact : BaseRequest
    {
        public CreateContact()
        {
            Action = "contacts";
            Method = HttpMethods.POST;
        }

        [JsonProperty("contact")]
        public Contact Contact { get; set; }
    }
}
