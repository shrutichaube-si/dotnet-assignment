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
        string[] sports = { "cricket,football", "soccer", "basketball", "tennis", "baseball", "golf", "running", "volleyball", "badminton", "swimming", "boxing", "table tennis", "skiing", "ice skating", "roller skating", "cricket", "rugby", "pool", "darts", "football", "bowling", "ice hockey", "surfing", "karate", "horse racing", "snowboarding", "skateboarding", "cycling", "archery", "fishing", "gymnastics", "figure skating", "rock climbing", "sumo wrestling", "taekwondo", "fencing", "water skiing", "jet skiing", "weight lifting", "scuba diving", "judo", "wind surfing", "kickboxing", "sky diving", "hang gliding", "bungee jumping", "lacrosse", "polo", "wrestling", "squash", "handball", "rowing", "sailing" };

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

        //ADDMATCH
        public void AddMatch()
        {
            var ids = from match in Matches select match.MatchId;
            try
            {
                Console.WriteLine("Enter MatchId : ");
                uint idu = uint.Parse(Console.ReadLine());
                int id = Convert.ToInt32(idu);
                if (ids.Contains(id))
                {
                    Console.WriteLine("Match with this Id already exists");
                    return;
                }
                Console.WriteLine("Enter Sport : ");
                string sport = Console.ReadLine();
                if (sport.Count() == 0)
                {
                    Console.WriteLine("Sport can't be empty");
                    return;
                }
                else if (!sports.Any(s => s.ToUpper() == sport.ToUpper()))
                {
                    Console.WriteLine("Invalid sport");
                    return;
                }
                Console.WriteLine("Enter Datetime (eg : DD/MM/YYYY) :");
                DateTime date = DateTime.Parse(Console.ReadLine());
                if (date <= DateTime.Now)
                {
                    Console.WriteLine("Date must be in future");
                    return;
                }
                Console.WriteLine("Enter Location : ");
                string loc = Console.ReadLine();
                if (loc.Count() == 0)
                {
                    Console.WriteLine("Location can't be empty");
                    return;
                }
                Console.WriteLine("Enter Home Team : ");
                string ht = Console.ReadLine();
                if (ht.Count() == 0)
                {
                    Console.WriteLine("Home Team can't be empty");
                    return;
                }
                Console.WriteLine("Enter Away Team : ");
                string at = Console.ReadLine();
                if (at.Count() == 0)
                {
                    Console.WriteLine("Away Team can't be empty");
                    return;
                }
                if (ht == at)
                {
                    Console.WriteLine("Home and Away team cant be same");
                    return;
                }
                Console.WriteLine("Enter Home Team Score :");
                uint hts = uint.Parse(Console.ReadLine());
                Console.WriteLine("Enter Away Team Score :");
                uint ats = uint.Parse(Console.ReadLine());

                Matches.Add(new MatchDetails(id, sport, date, loc, ht, at, hts, ats));
            }
            catch (Exception ex) { Console.WriteLine("Invalid input"); }
        }

        //SEARCH WITH MATCH ID
        public void Search()
        {
            Console.WriteLine("Enter the match id");
            int matchhid = Convert.ToInt32(Console.ReadLine());
            foreach (MatchDetails details in Matches)
            {
                if (matchhid == details.MatchId)
                {
                    Console.WriteLine("Match found");
                    Console.WriteLine(details.MatchId + " " + details.Sport + " " + details.MatchDateTime + " " + details.Location + " " + details.HomeTeam + " " + details.AwayTeam + " " + details.HomeTeamScore + " " + details.AwayTeamScore);
                    return;
                }
            }
            Console.WriteLine("match not found");
        }
        //DISPLAY
        public void Display()
        {
            foreach (var details in Matches)
            {

                Console.WriteLine(details.MatchId + " " + details.Sport + " " + details.MatchDateTime + " " + details.Location + " " + details.HomeTeam + " " + details.AwayTeam + " " + details.HomeTeamScore + " " + details.AwayTeamScore);
               
                Console.WriteLine("==============================");
            }
           
        }
        

        //UPDATE
        public void Update(int matchId, uint awayTeamScore, uint homeTeamScore)
        {

            foreach (MatchDetails details in Matches)
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

        //REMOVE
        public void Remove(int matchId)
        {
            foreach (MatchDetails details in Matches)
            {
                if (details.MatchId == matchId)
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
            Matches = (from match in Matches
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
                              where match.Sport.ToUpper() == spo
                              select match;

            foreach (MatchDetails details in filtersport)
            {
                Console.WriteLine(details.MatchId + " " + details.Sport + " " + details.Location + " " + details.HomeTeam + " " + details.AwayTeam + " " + details.HomeTeamScore + " " + details.AwayTeamScore);
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

        public void StatsbySport()
        {
            var sports = (from matches in Matches
                          select matches.Sport).Distinct();
            Dictionary<string, List<double>> sportscore = new Dictionary<string, List<double>>();



            foreach (var sport in sports)
            {
                double average = (from match in Matches where match.Sport.Equals(sport) select Convert.ToInt32(match.HomeTeamScore + match.AwayTeamScore) / 2).Average();
                double max = (from match in Matches where match.Sport.Equals(sport) select (match.HomeTeamScore)).Max();
                double min = (from match in Matches where match.Sport.Equals(sport) select (match.HomeTeamScore)).Min();

                sportscore.Add(sport.ToString(), new List<double> { average, max, min });
            }


            foreach (var item in sportscore)
            {

                Console.WriteLine($"{item.Key} has average score of {item.Value[0]} max score of {item.Value[1]} min score of {item.Value[2]}");
            }

        }

        //  Search by keyword

        public void SearchbyKeyword()
        {

            List<MatchDetails> ms;
            string c;


            Console.WriteLine("Enter keyword :");
            c = Console.ReadLine();
            c = c.ToLower();

            ms = (from match in Matches
                  where ((match.AwayTeam).ToLower().Contains(c)) || ((match.HomeTeam).ToLower().Contains(c)) || ((match.Sport).ToLower().Contains(c)) || ((match.Location).ToLower().Contains(c))
                  select match).ToList();
            if (ms.Count > 0)
            {
                foreach (var details in ms)
                {
                    Console.WriteLine(details.MatchId + " " + details.Sport + " " + details.MatchDateTime + " " + details.Location + " " + details.HomeTeam + " " + details.AwayTeam + " " + details.HomeTeamScore + " " + details.AwayTeamScore);

                }
            }
            else
            {
                Console.WriteLine("No matches found");
            }

        }


            //}
            // Validation
            public void AddMatch(MatchDetails match)
        {
            if (validation(match))
            {
                Matches.Add(match);
            }
        }
        public bool validation(MatchDetails match)
        {
            if (match.MatchId <= 0 || Matches.Any(m => m.MatchId == match.MatchId))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(match.Sport))
            {
                Console.WriteLine("Sport must not be empty.");
                return false;
            }

            if (match.MatchDateTime <= DateTime.Now)
            {
                Console.WriteLine("Match date and time must be in the future.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(match.Location))
            {
                Console.WriteLine("Location must not be empty.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(match.HomeTeam) || string.IsNullOrWhiteSpace(match.AwayTeam) || match.HomeTeam == match.AwayTeam)
            {
                Console.WriteLine("Home and away teams must not be empty or the same.");
                return false;
            }

            if (match.HomeTeamScore < 0 || match.AwayTeamScore < 0)
            {
                Console.WriteLine("Scores must be non-negative integers.");
                return false;
            }
            return true;
        }

        
    }
}
