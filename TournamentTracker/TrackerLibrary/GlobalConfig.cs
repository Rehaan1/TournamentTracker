using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;
using System.Configuration;

namespace TrackerLibrary
{
    /// <summary>
    /// The global configuration for the application.
    /// Note: This must be initialized at the beginning of the program.
    /// </summary>
    public static class GlobalConfig
    {
        /// <summary>
        /// This property holds the connections to the database and text files.
        /// <summary>
        public static IDataConnection Connection { get; private set; }

        /// <summary>
        /// This method initializes the connections to the database and text files.
        /// </summary>
        /// <param name="database">
        /// Initialize database connection.
        /// </param>
        /// <param name="textFiles">
        /// Initialize text files connection.
        /// </param>
        public static void InitializeConnections(DatabaseTypes db)
        {
            switch (db)
            {
                case DatabaseTypes.Sql:
                    SqlConnector sql = new SqlConnector();
                    Connection = sql;
                    break;
                case DatabaseTypes.TextFile:
                    // TODO - Create the Text Connection
                    TextConnector text = new TextConnector();
                    Connection = text;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Returns the connection string for the specified name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string ConnectionString(string name)
        {
            /** Note: System.Configuration.ConfigurationManager is used to access the configuration information for the application.
             * It is an older way of accessing configuration information. The newer way is to use Microsoft.Extensions.Configuration.
             * For the course of learning and following the tutorial , we will use the older way.
             */

            /** Note: the ConfigurationManager in the class library project accesses the configuration settings of the executing 
             * application's configuration file which in our case is TrackerUI.
             */
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
