using System;
using Newtonsoft.Json;

namespace ActiveCampaignSharp.Request.Contact
{
    public class UpdateContact : BaseIdRequest
    {
        public UpdateContact(string id)
        {
            Action = "contacts";
            Method = HttpMethods.POST;
            Id = id;
        }

        [JsonProperty("contact")]
        public Contact Contact { get; set; }
    }
}
