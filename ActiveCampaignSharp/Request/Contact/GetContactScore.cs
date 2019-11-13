using System;
namespace ActiveCampaignSharp.Request.Contact
{
    public class GetContactScore : BaseIdRequest
    {
        public GetContactScore(string id)
        {
            Action = "contacts";
            SubAction = "scoreValues";
            Method = HttpMethods.POST;
            Id = id;
        }
    }
}
