using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;

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
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();

        /// <summary>
        /// This method initializes the connections to the database and text files.
        /// </summary>
        /// <param name="database">
        /// Initialize database connection.
        /// </param>
        /// <param name="textFiles">
        /// Initialize text files connection.
        /// </param>
        public static void InitializeConnections(bool database, bool textFiles)
        {
            if(database)
            {
                // TODO -  Setup the SQL Connector Properly
                SqlConnector sql = new SqlConnector();
                Connections.Add(sql);
            }

            if (textFiles)
            {
                // TODO - Create the Text Connection
                TextConnector text = new TextConnector();
                Connections.Add(text);
            }
        }
    }
}
