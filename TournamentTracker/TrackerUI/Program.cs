using TrackerLibrary;

namespace TrackerUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();


            // Initialize the connections to the database and text files.
            TrackerLibrary.GlobalConfig.InitializeConnections(DatabaseTypes.Sql);

            Application.Run(new TournamentDashboardForm());
            //Application.Run(new TournamentDashboardForm());
        }
    }
}