using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
