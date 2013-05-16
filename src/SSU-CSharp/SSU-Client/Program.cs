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

            var result = client.SetDataValue(5362746, "T-Shirt size", "299157");
            Console.Out.WriteLine(result.Value);

            Console.In.ReadLine();
            Environment.Exit(0);
        }
    }
}
