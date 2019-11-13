using System;
namespace ActiveCampaignSharp.Request
{
    public abstract class BaseIdRequest : BaseRequest
    {
        // The numeric identifier of the resource. 
        public string Id { get; set; }

        public string SubAction { get; set; }

        public string ActionWithId => $"{Action}/{Id}{(!string.IsNullOrEmpty(SubAction) ? "/" + SubAction : "")}";
    }
}
