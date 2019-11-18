using System;
using System.Collections.Generic;
using System.Net;

namespace ActiveCampaignSharp.Request.Contact
{
    public class ContactSearchByEmail : BaseRequestWithFilter
    {
        public ContactSearchByEmail(string emailToSearch)
        {
            Method = HttpMethods.GET;
            Action = "contacts";
            FilterParamters = new Dictionary<string, string> { { "email", WebUtility.UrlEncode(emailToSearch) } };
        }
    }
}
