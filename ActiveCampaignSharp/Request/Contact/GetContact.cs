using System;
namespace ActiveCampaignSharp.Request.Contact
{
    public class GetContact : BaseIdRequest
    {
        public GetContact(string id)
        {
            Action = "contacts";
            Method = HttpMethods.GET;
            Id = id;
        }
    }
}
