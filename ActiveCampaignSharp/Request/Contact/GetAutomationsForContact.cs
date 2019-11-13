using System;
namespace ActiveCampaignSharp.Request.Contact
{
    public class GetAutomationsForContact : BaseIdRequest
    {
        public GetAutomationsForContact(string id)
        {
            Action = "contacts";
            SubAction = "contactAutomations";
            Method = HttpMethods.GET;
            Id = id;
        }
    }
}
