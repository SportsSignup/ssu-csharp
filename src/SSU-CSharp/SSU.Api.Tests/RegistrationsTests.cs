using Xunit;

namespace SSU.Api.Tests
{
    public class RegistrationsTests
    {
        [Fact]
        public void ShouldReturnRegistration()
        {
            var client = new SSURestClient(Credentials.TestLeagueSubdomain, Credentials.TestAccountSid,
                                           Credentials.TestAuthToken);
            var result = client.GetByRegistrationId(1);

            Assert.NotNull(result);
        }
    }
}