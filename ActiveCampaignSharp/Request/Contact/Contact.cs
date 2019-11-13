using System;
using Newtonsoft.Json;

namespace ActiveCampaignSharp.Request.Contact
{
    public class Contact
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
    }
}
