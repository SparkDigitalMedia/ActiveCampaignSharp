using System;
namespace ActiveCampaignSharp.Request.Contact
{
    public class GetAllContacts : BaseRequest
    {
        public GetAllContacts()
        {
            Method = HttpMethods.GET;
            Action = "contacts";
        }
    }
}
