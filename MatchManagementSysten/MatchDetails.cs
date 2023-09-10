using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public uint HomeTeamScore;
        public uint AwayTeamScore;

        public MatchDetails() { }
        public MatchDetails(int id,string sport,DateTime datetime,string location, string hometeam,string awayteam, uint hometesmscore,uint awayteamscore) { 
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
