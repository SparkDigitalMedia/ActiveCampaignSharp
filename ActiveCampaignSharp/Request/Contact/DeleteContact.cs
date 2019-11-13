using System;
namespace ActiveCampaignSharp.Request.Contact
{
    public class DeleteContact : BaseIdRequest
    {
        public DeleteContact(string id)
        {
            Action = "contacts";
            Method = HttpMethods.DELETE;
            Id = id;
        }
    }
}
