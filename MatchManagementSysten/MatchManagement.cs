using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchManagementSysten
{
    internal class MatchManagement
    {
        List<MatchDetails> MatchDetails = new List<MatchDetails>()
        {
            new MatchDetails(1,"cricket",new DateTime(2002,2,3),"Mumbai","chennai","mum",1,2),
            new MatchDetails(2,"football",new DateTime(2002,2,3),"Mumbai","chennai","mum",1,2),
            new MatchDetails(3,"table tennis",new DateTime(2002,2,3),"Mumbai","chennai","mum",1,2),
            new MatchDetails(4,"",new DateTime(2002,2,3),"Mumbai","chennai","mum",1,2),
            new MatchDetails(5,"carrom",new DateTime(2002,2,3),"Mumbai","chennai","mum",1,2),
            new MatchDetails(6,"carrom",new DateTime(2002,2,3),"Mumbai","chennai","mum",1,2),

        };
        public void Display()
        {
            foreach(var details in MatchDetails)
            {
                Console.WriteLine(details.MatchId+" "+details.Sport+" "+details.Location+" "+details.HomeTeam+" "+details.AwayTeam+" "+details.HomeTeamScore+" ",+details.AwayTeamScore);
                Console.WriteLine("==============================");
            }
        }
        public void Update(int matchId,int awayTeamScore,int homeTeamScore)
        {
            var match = MatchDetails.FirstOrDefault(m => m.MatchId == matchId);

            if(match != null)
            {
                match.AwayTeamScore = awayTeamScore;
                match.HomeTeamScore = homeTeamScore;
                Console.WriteLine($"id {matchId} is updated successfully");
            }
            else
            {
                Console.WriteLine($"id {matchId} is not found");
            }
        }
      
    }
}
