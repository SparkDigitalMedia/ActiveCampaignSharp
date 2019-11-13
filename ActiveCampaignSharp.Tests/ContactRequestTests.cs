using System;
using ActiveCampaignSharp.Request.Contact;
using Xunit;

namespace ActiveCampaignSharp.Tests
{
    public class ContactRequestTests
    {
        [Fact]
        public void GetContactHasRightProps()
        {
            var getContact = new GetContact("123");

            Assert.Equal(HttpMethods.GET, getContact.Method);
            Assert.Equal("contacts", getContact.Action);
            Assert.Equal("contacts/123", getContact.ActionWithId);
        }

        [Fact]
        public void GetContactAutomationsHasRightProps()
        {
            var getContactAutomations = new GetAutomationsForContact("123");

            Assert.Equal(HttpMethods.GET, getContactAutomations.Method);
            Assert.Equal("contacts", getContactAutomations.Action);
            Assert.Equal("contacts/123/contactAutomations", getContactAutomations.ActionWithId);
        }
    }
}
