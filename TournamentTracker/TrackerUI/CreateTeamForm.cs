﻿using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTeamForm : Form
    {

        private List<PersonModel> availableTeamMembers = GlobalConfig.Connection.GetPersonAll();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();

        private ITeamRequester callingForm;

        public CreateTeamForm()
        {
            InitializeComponent();

            //CreateSampleData();

            WireUpLists();
        }

        public CreateTeamForm(ITeamRequester caller)
        {
            InitializeComponent();

            callingForm = caller;

            //CreateSampleData();

            WireUpLists();
        }

        private void CreateSampleData()
        {
            availableTeamMembers.Add(new PersonModel { FirstName = "Tim", LastName = "Corey" });
            availableTeamMembers.Add(new PersonModel { FirstName = "Sue", LastName = "Storm" });

            selectedTeamMembers.Add(new PersonModel { FirstName = "Jane", LastName = "Smith" });
            selectedTeamMembers.Add(new PersonModel { FirstName = "Bill", LastName = "Jones" });
        }

        private void WireUpLists()
        {
            selectTeamMemberDropDown.DataSource = null;

            selectTeamMemberDropDown.DataSource = availableTeamMembers;
            selectTeamMemberDropDown.DisplayMember = "FullName";

            teamMembersListBox.DataSource = null;

            teamMembersListBox.DataSource = selectedTeamMembers;
            teamMembersListBox.DisplayMember = "FullName";
        }

        private void cellphoneLabel_Click(object sender, EventArgs e)
        {

        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel p = new PersonModel();
                p.FirstName = firstNameValue.Text;
                p.LastName = lastNameValue.Text;
                p.EmailAddress = emailValue.Text;
                p.CellphoneNumber = cellphoneValue.Text;

                GlobalConfig.Connection.CreatePerson(p);

                selectedTeamMembers.Add(p);

                WireUpLists();

                firstNameValue.Text = "";
                lastNameValue.Text = "";
                emailValue.Text = "";
                cellphoneValue.Text = "";
            }
            else
            {
                MessageBox.Show("You need to fill in all of the fields.");
            }

        }

        private bool ValidateForm()
        {
            if (firstNameValue.Text.Length == 0)
            {
                return false;
            }

            if (lastNameValue.Text.Length == 0)
            {
                return false;
            }

            if (emailValue.Text.Length == 0)
            {
                return false;
            }

            if (cellphoneValue.Text.Length == 0)
            {
                return false;
            }

            return true;
        }

        private void selectTeamMemberDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)selectTeamMemberDropDown.SelectedItem;

            if (p == null)
            {
                MessageBox.Show("You need to select a member to add.");
                return;
            }

            availableTeamMembers.Remove(p);
            selectedTeamMembers.Add(p);

            WireUpLists();
        }

        private void removeSelectedMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)teamMembersListBox.SelectedItem;

            if (p == null)
            {
                MessageBox.Show("You need to select a member to remove.");
                return;
            }

            selectedTeamMembers.Remove(p);
            availableTeamMembers.Add(p);

            WireUpLists();
        }

        private void createTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel t = new TeamModel();

            t.TeamName = teamNameValue.Text;
            t.TeamMembers = selectedTeamMembers;

            GlobalConfig.Connection.CreateTeam(t);

            callingForm.TeamComplete(t);

            this.Close();
        }
    }
}
