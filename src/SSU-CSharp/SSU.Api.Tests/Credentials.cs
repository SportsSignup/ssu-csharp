using System;

namespace SSU.Api.Tests
{
    public class Credentials
    {
        public static string TestLeagueSid
        {
            get { return new Guid().ToString(); }
        }

        public static string TestAccountSid
        {
            get { return new Guid().ToString(); }
        }

        public static string TestAuthToken
        {
            get { return new Guid().ToString(); }
        }
    }
}
