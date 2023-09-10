using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchManagementSysten
{
    internal class MatchDetails
    {
        public int MatchId;
        public String Sport;
        public DateTime MatchDateTime;
        public String Location;
       public   String HomeTeam;
       public  String AwayTeam;
        public int HomeTeamScore;
        public int AwayTeamScore;

        public MatchDetails(int id,string sport,DateTime datetime,string location, string hometeam,string awayteam, int hometesmscore,int awayteamscore) { 
            MatchId = id;
            Sport = sport;
            MatchDateTime = datetime;
            Location = location;
            HomeTeam = hometeam;
            AwayTeam = awayteam;
            AwayTeamScore = awayteamscore;
            HomeTeamScore = hometesmscore;

        }
       

    }
}
