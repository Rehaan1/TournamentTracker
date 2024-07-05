using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        // TODO - Make the CreatePrize method actually save to the database

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
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("Tournaments")))
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
    }
}
