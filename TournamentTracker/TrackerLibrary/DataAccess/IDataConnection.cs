using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public interface IDataConnection
    {
        void CreatePrize(PrizeModel model);

        void CreatePerson(PersonModel model);

        List<PersonModel> GetPersonAll();

        void CreateTeam(TeamModel model);

        List<TeamModel> GetTeamAll();

        void CreateTournament(TournamentModel model);

        List<TournamentModel> GetTournamentAll();

        void UpdateMatchup(MatchupModel model);

        void CompleteTournament(TournamentModel model);
    }
}
