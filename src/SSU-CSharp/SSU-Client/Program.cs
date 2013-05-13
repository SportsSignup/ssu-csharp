using System;
using System.Configuration;

namespace SSU_Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            var client = new SSU.SSURestClient(ConfigurationManager.AppSettings["leagueSID"],
                                               ConfigurationManager.AppSettings["accountSID"],
                                               ConfigurationManager.AppSettings["authToken"]);

            var sessions = client.ListActiveSessions();

            Console.Out.WriteLine(sessions.Count);
        }
    }
}
