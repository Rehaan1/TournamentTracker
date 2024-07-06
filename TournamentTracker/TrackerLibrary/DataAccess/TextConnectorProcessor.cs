using System.Configuration;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess.TextHelpers
{
    public static class TextConnectorProcessor
    {

        /** Note: Extension Methods allow users to add new methods to existing types without 
         * creating a new derived type, recompiling, or otherwise modifying the original type. 
         * Extension methods are a special kind of static method, but they are called as if 
         * they were instance methods on the extended type. For client code written in C#, 
         * there is no apparent difference between calling an extension method and the methods 
         * that are actually defined in a type.
         */

        /// <summary>
        /// Takes the filename and returns the full file path.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>
        /// The full file path.
        /// </returns>
        public static string FullFilePath(this string fileName)
        {
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{fileName}";
        }

        /// <summary>
        /// Reads the text file and returns the list of strings.
        /// </summary>
        /// <param name="file"></param>
        /// <returns>
        /// The list of strings from the text file.
        /// </returns>
        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        /// <summary>
        /// Takes the list of lines of a text file and returns the list of PrizeModel objects.
        /// </summary>
        /// <param name="lines"></param>
        /// <returns>
        /// List of PrizeModel objects.
        /// </returns>
        public static List<PrizeModel> ConvertToPrizeModels(this List<String> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                PrizeModel p = new PrizeModel();
                p.Id = int.Parse(cols[0]);
                p.PlaceNumber = int.Parse(cols[1]);
                p.PlaceName = cols[2];
                p.PrizeAmount = decimal.Parse(cols[3]);
                p.PrizePercentage = double.Parse(cols[4]);
                output.Add(p);
            }

            return output;
        }

        /// <summary>
        /// Takes the list of PrizeModel objects and saves them to the text file.
        /// </summary>
        /// <param name="models"></param>
        /// <param name="fileName"></param>
        public static void SaveToPrizeFile(this List<PrizeModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PrizeModel p in models)
            {
                lines.Add($"{p.Id},{p.PlaceNumber},{p.PlaceName},{p.PrizeAmount},{p.PrizePercentage}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        /// <summary>
        /// Takes the list of lines of a text file and returns the list of PersonModel objects.
        /// </summary>
        /// <param name="lines"></param>
        /// <returns>
        /// List of PersonModel objects.
        /// </returns>
        public static List<PersonModel> ConvertToPersonModels(this List<String> lines)
        {
            List<PersonModel> output = new List<PersonModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                PersonModel p = new PersonModel();
                p.Id = int.Parse(cols[0]);
                p.FirstName = cols[1];
                p.LastName = cols[2];
                p.EmailAddress = cols[3];
                p.CellphoneNumber = cols[4];

                output.Add(p);
            }

            return output;
        }

        /// <summary>
        /// Takes the list of PersonModel objects and saves them to the text file.
        /// </summary>
        /// <param name="models"></param>
        /// <param name="fileName"></param>
        public static void SaveToPeopleFile(this List<PersonModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PersonModel p in models)
            {
                lines.Add($"{p.Id},{p.FirstName},{p.LastName},{p.EmailAddress},{p.CellphoneNumber}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        /// <summary>
        /// Takes the list of lines of a text file and returns the list of TeamModel objects.
        /// </summary>
        /// <param name="lines"></param>
        /// <returns>
        /// List of TeamModel objects.
        /// </returns>
        public static List<TeamModel> ConvertToTeamModels(this List<String> lines, string peopleFileName)
        {
            /** Note: Data stored as text in the text file.
            * id,team name,list of ids of each person separated by the pipe
            * 3,Tim's Team,1|3|5
            */

            List<TeamModel> output = new List<TeamModel>();
            List<PersonModel> people = peopleFileName.FullFilePath().LoadFile().ConvertToPersonModels();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                TeamModel t = new TeamModel();
                t.Id = int.Parse(cols[0]);
                t.TeamName = cols[1];

                string[] personIds = cols[2].Split('|');

                foreach (string id in personIds)
                {
                    t.TeamMembers.Add(people.Where(x => x.Id == int.Parse(id)).First());
                }

                output.Add(t);
            }

            return output;
        }

        /// <summary>
        /// Takes the list of TeamModel objects and saves them to the text file.
        /// </summary>
        /// <param name="models"></param>
        /// <param name="fileName"></param>
        public static void SaveToTeamFile(this List<TeamModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (TeamModel p in models)
            {
                lines.Add($"{p.Id},{p.TeamName},{ConvertPeopleListToString(p.TeamMembers)}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        /// <summary>
        /// Takes the list of PersonModel objects returns a piped string of each id.
        /// </summary>
        /// <param name="people"></param>
        /// <returns>
        /// String of each id separated by a pipe.
        /// </returns>
        private static string ConvertPeopleListToString(List<PersonModel> people)
        {
            string output = "";

            if (people.Count == 0)
            {
                return "";
            }

            foreach (PersonModel p in people)
            {
                output += $"{p.Id}|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }

        public static List<TournamentModel> ConvertToTournamentModels(
            this List<string> lines,
            string teamFile,
            string peopleFile,
            string prizeFile)
        {
            //id, TournamentName, EntryFee, (id|id|id - Entered Teams), (id|id|id - Prizes),
            //(Rounds - id^id^id|id^id^id|id^id^id|)
            List<TournamentModel> output = new List<TournamentModel>();
            List<TeamModel> teams = teamFile.FullFilePath().LoadFile().ConvertToTeamModels(peopleFile);
            List<PrizeModel> prizes = prizeFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            foreach (string line in lines)
            {
                TournamentModel tm = new TournamentModel();
                string[] cols = line.Split(',');
                tm.Id = int.Parse(cols[0]);
                tm.TournamentName = cols[1];
                tm.EntryFee = decimal.Parse(cols[2]);

                string[] teamIds = cols[3].Split('|');
                foreach (string id in teamIds)
                {
                    tm.EnteredTeams.Add(teams.Where(teams => teams.Id == int.Parse(id)).First());
                }

                string[] prizeIds = cols[4].Split('|');

                foreach (string id in prizeIds)
                {
                    tm.Prizes.Add(prizes.Where(prizes => prizes.Id == int.Parse(id)).First());
                }

                // TODO: Capture Round Information
            }

            return output;
        }
    }
}
