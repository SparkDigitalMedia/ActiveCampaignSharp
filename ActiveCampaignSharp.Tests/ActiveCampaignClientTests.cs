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
