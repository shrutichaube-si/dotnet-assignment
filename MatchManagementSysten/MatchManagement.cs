using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchManagementSysten
{
    internal class MatchManagement
    {
        List<MatchDetails> Matches = new List<MatchDetails>()
        {
            new MatchDetails(1,"cricket",new DateTime(2002,1,1),"goa","Mumbai","chennai",1,2),
            new MatchDetails(2,"football",new DateTime(2002,2,1),"delhi","delhi","chennai",3,4),
            new MatchDetails(3,"table tennis",new DateTime(2002,3,1),"mumbai","bangalore","chennai",5,6),
            new MatchDetails(4,"volleyball",new DateTime(2002,4,1),"Goa","UP","chennai",7,8),
            new MatchDetails(5,"chess",new DateTime(2002,5,1),"kashmir","madras","chennai",1,3),
            new MatchDetails(6,"carrom",new DateTime(2002,6,1),"vasai","gujarat","chennai",9,2),
            new MatchDetails(7,"cricket",new DateTime(2002,6,1),"vasai","gujarat","chennai",9,2),


        };

         
        public void Search()
        {
            Console.WriteLine("Enter the match id");
            int matchhid = Convert.ToInt32(Console.ReadLine());
            foreach(MatchDetails details in Matches)
            {
                if(matchhid == details.MatchId)
                {
                    Console.WriteLine("Match found");
                    Console.WriteLine(details.MatchId + " " + details.Sport + " " + details.MatchDateTime+ " " + details.Location + " " + details.HomeTeam + " " + details.AwayTeam + " " + details.HomeTeamScore + " " +details.AwayTeamScore);
                    return;
                }
            }
            Console.WriteLine("match not found");
        }
        public void Display()
        {
            foreach(var details in Matches)
            {
                
                Console.WriteLine(details.MatchId+" "+details.Sport+" "+details.MatchDateTime+" "+details.Location+" "+details.HomeTeam+" "+details.AwayTeam+" "+details.HomeTeamScore+" "+details.AwayTeamScore);
                Console.Write(details.AwayTeamScore);
                Console.WriteLine("==============================");
            }
        }
        public void Update(int matchId,int awayTeamScore,int homeTeamScore)
        {
           
           foreach(MatchDetails details in Matches)
            {
                if (details.MatchId == matchId)
                {
                    details.AwayTeamScore = awayTeamScore;
                    details.HomeTeamScore = homeTeamScore;
                
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine($"id {matchId} is updated successfully");
                    Console.WriteLine();
                    Console.WriteLine("--------------------------------------");
                    return;
                }
            }
            Console.WriteLine("match not found");
        }
        public void Remove(int matchId) {
            foreach(MatchDetails details in Matches)
            {
                if(details.MatchId == matchId)
                {
                    Matches.Remove(details);
                    Console.WriteLine("removed successfully");
                    return;
                }
            }
            Console.WriteLine("not found");
                }

        // Sorting
        public void SortbySport()
        {
            Matches = (from match in Matches
                             orderby match.Sport
                             select match).ToList();
            this.Display();
        }
        public void SortByLocation()
        {
            Matches=(from   match in Matches
                     orderby match.Location
                     select match).ToList();
            this.Display();                     
        }
        public void SortByDate()
        {
            Matches = (from match in Matches
                       orderby match.MatchDateTime
                       select match).ToList();
            this.Display();
        }
       // FILTERING
       public void FilterBySports()
        {
            Console.WriteLine("Enter the sports to filter the data:");
            string spo = Console.ReadLine().ToUpper();
            var filtersport = from match in Matches
                              where match.Sport.ToUpper()==spo
                               select match;

            foreach (MatchDetails details in filtersport)
            {
                Console.WriteLine(details.MatchId+" "+details.Sport+" "+details.Location+" " + details.HomeTeam + " " + details.AwayTeam + " " + details.HomeTeamScore + " " + details.AwayTeamScore);
            }
        }
        public void FilterByLocation()
        {
            Console.WriteLine("Enter the Location to filter the data:");
            string loc = Console.ReadLine().ToUpper();
            var filterlocation = from match in Matches
                              where match.Location.ToUpper() == loc
                              select match;

            foreach (MatchDetails details in filterlocation)
            {
                Console.WriteLine(details.MatchId + " " + details.Sport + " " + details.Location + " " + details.HomeTeam + " " + details.AwayTeam + " " + details.HomeTeamScore + " " + details.AwayTeamScore);
            }
        }

        //Statistics



    }
}
