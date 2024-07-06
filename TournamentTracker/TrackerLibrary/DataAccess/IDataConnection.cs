using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public interface IDataConnection
    {
        PrizeModel CreatePrize(PrizeModel model);

        PersonModel CreatePerson(PersonModel model);

        List<PersonModel> GetPersonAll();

        TeamModel CreateTeam(TeamModel model);

        List<TeamModel> GetTeamAll();

        TournamentModel CreateTournament(TournamentModel model);
    }
}
