using Dapper;
using System.Data;
using System.Reflection;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {

        private const string db = "Tournaments";

        /// <summary>
        /// Saves a new prize to the database.
        /// </summary>
        /// <param name="model">
        /// The prize information.
        /// </param>
        /// <returns>
        /// The prize information, including the unique identifier.
        /// </returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            // Creates a connection to the database.
            /** Note: The using statement ensures that the connection is closed and disposed when the code block exits. Also,
            * it is used to create a scope for the objects to be used.
            */
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                // This is a part of dapper library. It is used to pass the parameters to the stored procedure.
                var p = new DynamicParameters();
                p.Add("@PlaceNumber", model.PlaceNumber);
                p.Add("@PlaceName", model.PlaceName);
                p.Add("@PrizeAmount", model.PrizeAmount);
                p.Add("@PrizePercentage", model.PrizePercentage);
                // This is used to get the output parameter from the stored procedure.
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                // Here dbo.spPrizes_Insert is the stored procedure name. We are passing the parameters to the stored procedure to execute.
                connection.Execute("dbo.spPrizes_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");

                return model;
            }
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
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@FirstName", model.FirstName);
                p.Add("@LastName", model.LastName);
                p.Add("@EmailAddress", model.EmailAddress);
                p.Add("@CellphoneNumber", model.CellphoneNumber);
                
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                // Here dbo.spPrizes_Insert is the stored procedure name. We are passing the parameters to the stored procedure to execute.
                connection.Execute("dbo.spPeople_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");

                return model;
            }
        }

        /// <summary>
        /// Returns all the people.
        /// </summary>
        /// <returns>
        /// List of PersonModel objects.
        /// </returns>
        public List<PersonModel> GetPersonAll()
        {
            List<PersonModel> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                output = connection.Query<PersonModel>("dbo.spPeople_GetAll").ToList();
            }

            return output;
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
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@TeamName", model.TeamName);

                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTeams_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");

                foreach (PersonModel tm in model.TeamMembers)
                {
                    p = new DynamicParameters();
                    p.Add("@TeamId", model.Id);
                    p.Add("@PersonId", tm.Id);

                    connection.Execute("dbo.spTeamMembers_Insert", p, commandType: CommandType.StoredProcedure);
                }

                return model;
            }
        }
    }
}
