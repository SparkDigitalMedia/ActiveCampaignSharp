using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Xunit;

namespace ActiveCampaignSharp.Tests
{
    public class ActiveCampaignClientTests
    {
        public ActiveCampaignClientTests()
        {
        }

        [Fact]
        public void ConfigurationWithoutApiKeyThrows()
        {
            Assert.Throws<ActiveCampaignException>(() => new ActiveCampaignClient("", ""));
        }

        [Fact]
        public void DummyRequestReturnsSuccessAsync()
        {
            Assert.True(true);
        }
    }
}
