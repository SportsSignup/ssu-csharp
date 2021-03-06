﻿using System;
using System.Configuration;
using System.Linq;

namespace SSU_Client
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var client = new SSU.SSURestClient(ConfigurationManager.AppSettings["leagueSubdomain"],
                                               ConfigurationManager.AppSettings["accountSID"],
                                               ConfigurationManager.AppSettings["authToken"]);

            var sessions = client.ListActiveSessions();
            Console.Out.WriteLine(sessions.Count);

            sessions = client.GetPublicSessions();
            Console.Out.WriteLine(sessions.Count);

            var teams = client.TeamsBySessionId(sessions.First().Id.Value);
            Console.Out.WriteLine(teams.First().Name);


//            var result = client.SetDataValue(5362746, "T-Shirt size", "299157");
//            Console.Out.WriteLine(result.Value);

            //result = client.SetDataValue(5362746, "JerseyNumber", "1234");
            //           result = client.SetDataValue(5362746, "Jersey#", "1234");
            //           Console.Out.WriteLine(result.Value);

//            var result = client.CreateTeamInDivision(202795, "Go Go Gadget");
//            Console.Out.WriteLine(result.Name);

            Console.In.ReadLine();
            Environment.Exit(0);
        }
    }
}