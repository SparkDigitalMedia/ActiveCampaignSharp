using System;
using Newtonsoft.Json;

namespace ActiveCampaignSharp.Request.Contact
{
    public class CreateOrUpdateContact : BaseRequest
    {
        public CreateOrUpdateContact()
        {
            Action = "contact/sync";
            Method = HttpMethods.POST;
        }

        [JsonProperty("contact")]
        public Contact Contact { get; set; }
    }
}
