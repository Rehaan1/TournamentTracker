using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class TournamentDashboardForm : Form
    {
        List<TournamentModel> tournaments = GlobalConfig.Connection.GetTournamentAll();

        public TournamentDashboardForm()
        {
            InitializeComponent();

            WireUpList();
        }

        private void WireUpList()
        {
            loadExistingTournamentDropDown.DataSource = tournaments;
            loadExistingTournamentDropDown.DisplayMember = "TournamentName";
        }

        private void createTournamentButton_Click(object sender, EventArgs e)
        {

        }

        private void loadExistingTournamentDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
