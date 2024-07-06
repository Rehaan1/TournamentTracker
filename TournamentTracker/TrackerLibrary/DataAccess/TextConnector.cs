using TrackerLibrary.DataAccess.TextHelpers;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {

        private const string PrizesFile = "PrizeModel.csv";
        private const string PeopleFile = "PersonModel.csv";
        private const string TeamsFile = "TeamModel.csv";
        private const string TournamentFile = "TournamentModel.csv";

        /// <summary>
        /// Saves a new prize to the text file.
        /// </summary>
        /// <param name="model">
        /// The prize information.
        /// </param>
        /// <returns>
        /// The prize information, including the unique identifier.
        /// </returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            /** Note: We are using Extension methods defined in TextConnectorProcessor
             */
            // Load the text file
            List<string> fileLines = PrizesFile.FullFilePath().LoadFile();

            // Convert the text to List<PrizeModel>
            List<PrizeModel> prizes = fileLines.ConvertToPrizeModels();

            // Find the max ID
            int currentId = 0;

            if (prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id;
            }

            // Add the new record with the new ID  (max + 1)
            model.Id = currentId + 1;
            prizes.Add(model);

            // Converge the prizes to List<string> and Save the List<string> to the text file
            prizes.SaveToPrizeFile(PrizesFile);

            return model;
        }

        /// <summary>
        /// Saves a new person to the database.
        /// </summary>
        /// <param name="model">
        /// The person information
        /// </param>
        /// <returns>
        /// The person information, including the unique identifier.
        /// </returns>
        public PersonModel CreatePerson(PersonModel model)
        {
            List<string> fileLines = PeopleFile.FullFilePath().LoadFile();

            List<PersonModel> people = fileLines.ConvertToPersonModels();

            int currentId = 0;

            if (people.Count > 0)
            {
                currentId = people.OrderByDescending(x => x.Id).First().Id;
            }

            model.Id = currentId + 1;
            people.Add(model);

            people.SaveToPeopleFile(PeopleFile);

            return model;
        }

        /// <summary>
        /// Returns all the people from the text file.
        /// </summary>
        /// <returns>
        /// List of PersonModel objects.
        /// </returns>
        public List<PersonModel> GetPersonAll()
        {
            return PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
        }

        /// <summary>
        /// Creates a new team.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// The team information, including the unique identifier.
        /// </returns>
        public TeamModel CreateTeam(TeamModel model)
        {
            List<TeamModel> teams = TeamsFile.FullFilePath().LoadFile().ConvertToTeamModels(PeopleFile);

            int currentId = 0;
            if (teams.Count > 0)
            {
                currentId = teams.OrderByDescending(x => x.Id).First().Id;
            }

            model.Id = currentId + 1;
            teams.Add(model);

            teams.SaveToTeamFile(TeamsFile);

            return model;
        }

        /// <summary>
        /// Gets all the teams from the text file.
        /// </summary>
        /// <returns>
        /// List of TeamModel objects.
        /// </returns>
        public List<TeamModel> GetTeamAll()
        {
            return TeamsFile.FullFilePath().LoadFile().ConvertToTeamModels(PeopleFile);
        }

        /// <summary>
        /// Creates a new tournament.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// Tournament information, including the unique identifier.
        /// </returns>
        public TournamentModel CreateTournament(TournamentModel model)
        {
            List<TournamentModel> tournamentModels = TournamentFile.
                FullFilePath().
                LoadFile().
                ConvertToTournamentModels(TeamsFile, PeopleFile, PrizesFile);

            int currentId = 0;

            if (tournamentModels.Count > 0)
            {
                currentId = tournamentModels.OrderByDescending(x => x.Id).First().Id;
            }

            model.Id = currentId + 1;

            tournamentModels.Add(model);

            tournamentModels.SaveToTournamentFile(TournamentFile);
        }
    }
}
