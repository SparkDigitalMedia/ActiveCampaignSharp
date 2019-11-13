using System;
using Newtonsoft.Json;

namespace ActiveCampaignSharp.Request.Contact
{
    public class UpdateListStatusForContact : BaseRequest
    {
        public UpdateListStatusForContact()
        {
            Action = "contactLists";
            Method = HttpMethods.POST;
        }

        [JsonProperty("contactList")]
        public ContactList ContactList { get; set; }
    }
}
