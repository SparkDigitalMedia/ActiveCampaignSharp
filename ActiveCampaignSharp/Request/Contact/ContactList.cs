using Newtonsoft.Json;

namespace ActiveCampaignSharp.Request.Contact
{
    public class ContactList
    {
        [JsonProperty("list")]
        public int List { get; set; }
        [JsonProperty("contact")]
        public int Contact { get; set; }
        [JsonProperty("status")]
        public ContactListStatusEnum Status { get; set; }
    }
}
