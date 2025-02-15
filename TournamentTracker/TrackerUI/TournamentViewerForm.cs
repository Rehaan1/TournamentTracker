using System.ComponentModel;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class TournamentViewerForm : Form
    {
        private TournamentModel tournament;
        BindingList<int> rounds = new BindingList<int>();
        BindingList<MatchupModel> selectedMatchups = new BindingList<MatchupModel>();

        public TournamentViewerForm(TournamentModel tournamentModel)
        {
            InitializeComponent();

            tournament = tournamentModel;

            // Custom event subscriber
            tournament.OnTournamentComplete += Tournament_OnTournamentComplete;

            WireUpLists();

            LoadFormData();

            LoadRounds();
        }

        private void Tournament_OnTournamentComplete(object? sender, DateTime e)
        {
            this.Close();
        }

        private void WireUpLists()
        {
            roundDropDown.DataSource = rounds;

            matchupListBox.DataSource = selectedMatchups;
            matchupListBox.DisplayMember = "DisplayName";
        }

        private void LoadRounds()
        {
            rounds.Clear();

            rounds.Add(1);
            int currRound = 1;

            foreach (List<MatchupModel> matchups in tournament.Rounds)
            {
                if (matchups.First().MatchupRound > currRound)
                {
                    currRound = matchups.First().MatchupRound;
                    rounds.Add(currRound);
                }
            }

            LoadMatchups(1);
        }

        private void LoadFormData()
        {
            tournamentName.Text = tournament.TournamentName;
        }

        private void TournamentViewerForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void roundLabel_Click(object sender, EventArgs e)
        {

        }

        private void roundDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchups((int)roundDropDown.SelectedItem);
        }

        private void LoadMatchups(int round)
        {
            foreach (List<MatchupModel> matchups in tournament.Rounds)
            {
                if (matchups.First().MatchupRound == round)
                {
                    selectedMatchups.Clear();
                    foreach (MatchupModel m in matchups)
                    {
                        if (m.Winner == null || !unplayedOnlyCheckbox.Checked)
                        {
                            selectedMatchups.Add(m);
                        }
                    }
                }
            }

            if (selectedMatchups.Count > 0)
            {
                LoadMatchup(selectedMatchups.First());
            }

            DisplayMatchupInfo();
        }

        private void DisplayMatchupInfo()
        {
            bool isVisible = selectedMatchups.Count > 0;

            teamOneName.Visible = isVisible;
            teamOneScoreLabel.Visible = isVisible;
            teamOneScoreValue.Visible = isVisible;
            teamTwoName.Visible = isVisible;
            teamTwoScoreLabel.Visible = isVisible;
            teamTwoScoreValue.Visible = isVisible;
            versusLabel.Visible = isVisible;
            scoreButton.Visible = isVisible;
        }

        private void unplayedOnlyCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            LoadMatchups((int)roundDropDown.SelectedItem);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private string ValidateData()
        {
            string output = "";
            double teamOneScore = 0;
            double teamTwoScore = 0;

            bool scoreOneValid = double.TryParse(teamOneScoreValue.Text, out teamOneScore);
            bool scoreTwoValid = double.TryParse(teamTwoScoreValue.Text, out teamTwoScore);

            if (!scoreOneValid)
            {
                output = "The Score one value is not a valid number";
            }
            else if (!scoreTwoValid)
            {
                output = "The Score two value is not a valid number";
            }
            else if (teamOneScore == 0 && teamTwoScore == 0)
            {
                output = "You did not enter a score for either team";
            }
            else if (teamOneScore == teamTwoScore)
            {
                output = "We do not allow ties in this application.";
            }

            return output;
        }

        private void scoreButton_Click(object sender, EventArgs e)
        {
            string errorMessage = ValidateData();
            if (errorMessage.Length > 0)
            {
                MessageBox.Show($"Input Error: {errorMessage}");
                return;
            }

            MatchupModel m = (MatchupModel)matchupListBox.SelectedItem;
            double teamOneScore = 0;
            double teamTwoScore = 0;

            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[i].TeamCompeting != null)
                    {
                        bool scoreValid = double.TryParse(teamOneScoreValue.Text, out teamOneScore);

                        if (scoreValid)
                            m.Entries[i].Score = teamOneScore;
                        else
                        {
                            MessageBox.Show("Please enter a valid score for team 1.");
                            return;
                        }

                    }
                }

                if (i == 1)
                {
                    if (m.Entries[i].TeamCompeting != null)
                    {
                        bool scoreValid = double.TryParse(teamTwoScoreValue.Text, out teamTwoScore);

                        if (scoreValid)
                            m.Entries[i].Score = teamTwoScore;
                        else
                        {
                            MessageBox.Show("Please enter a valid score for team 1.");
                            return;
                        }
                    }
                }
            }

            try
            {
                TournamentLogic.UpdateTournamentResults(tournament);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The Application had the following error: {ex.Message}");
                return;
            }

            LoadMatchups((int)roundDropDown.SelectedItem);
        }

        private void LoadMatchup(MatchupModel m)
        {
            if (m == null)
            {
                return;
            }
            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[i].TeamCompeting != null)
                    {
                        teamOneName.Text = m.Entries[i].TeamCompeting.TeamName;
                        teamOneScoreValue.Text = m.Entries[i].Score.ToString();

                        teamTwoName.Text = "<bye>";
                        teamTwoScoreValue.Text = "0";
                    }
                    else
                    {
                        teamOneName.Text = "Not yet set";
                        teamOneScoreValue.Text = "";
                    }
                }

                if (i == 1)
                {
                    if (m.Entries[i].TeamCompeting != null)
                    {
                        teamTwoName.Text = m.Entries[i].TeamCompeting.TeamName;
                        teamTwoScoreValue.Text = m.Entries[i].Score.ToString();
                    }
                    else
                    {
                        teamTwoName.Text = "Not yet set";
                        teamTwoScoreValue.Text = "";
                    }
                }
            }

        }

        private void matchupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchup((MatchupModel)matchupListBox.SelectedItem);
        }
    }
}
