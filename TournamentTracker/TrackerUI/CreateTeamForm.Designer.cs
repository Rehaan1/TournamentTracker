namespace TrackerUI
{
    partial class CreateTeamForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            teamNameValue = new TextBox();
            teamNameLabel = new Label();
            headerLabel = new Label();
            addMemberButton = new Button();
            selectTeamMemberDropDown = new ComboBox();
            selectTeamMemberLabel = new Label();
            groupBox1 = new GroupBox();
            createMemberButton = new Button();
            cellphoneValue = new TextBox();
            cellphoneLabel = new Label();
            emailValue = new TextBox();
            emailLabel = new Label();
            lastNameValue = new TextBox();
            lastNameLabel = new Label();
            firstNameValue = new TextBox();
            firstNameLabel = new Label();
            teamMembersListBox = new ListBox();
            deleteSelectedMemberButton = new Button();
            createTeamButton = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // teamNameValue
            // 
            teamNameValue.Location = new Point(25, 141);
            teamNameValue.Name = "teamNameValue";
            teamNameValue.Size = new Size(537, 43);
            teamNameValue.TabIndex = 13;
            // 
            // teamNameLabel
            // 
            teamNameLabel.Font = new Font("Segoe UI Light", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            teamNameLabel.ForeColor = SystemColors.MenuHighlight;
            teamNameLabel.Location = new Point(25, 91);
            teamNameLabel.Name = "teamNameLabel";
            teamNameLabel.Size = new Size(283, 47);
            teamNameLabel.TabIndex = 12;
            teamNameLabel.Text = "Team Name";
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI Light", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            headerLabel.ForeColor = SystemColors.MenuHighlight;
            headerLabel.Location = new Point(9, 9);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(272, 62);
            headerLabel.TabIndex = 11;
            headerLabel.Text = "Create Team";
            // 
            // addMemberButton
            // 
            addMemberButton.FlatAppearance.BorderColor = Color.Silver;
            addMemberButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 102, 102);
            addMemberButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(242, 242, 242);
            addMemberButton.FlatStyle = FlatStyle.Flat;
            addMemberButton.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addMemberButton.ForeColor = SystemColors.MenuHighlight;
            addMemberButton.Location = new Point(121, 331);
            addMemberButton.Name = "addMemberButton";
            addMemberButton.Size = new Size(342, 51);
            addMemberButton.TabIndex = 19;
            addMemberButton.Text = "Add Member";
            addMemberButton.UseVisualStyleBackColor = true;
            // 
            // selectTeamMemberDropDown
            // 
            selectTeamMemberDropDown.FormattingEnabled = true;
            selectTeamMemberDropDown.Location = new Point(25, 265);
            selectTeamMemberDropDown.Name = "selectTeamMemberDropDown";
            selectTeamMemberDropDown.Size = new Size(537, 45);
            selectTeamMemberDropDown.TabIndex = 18;
            // 
            // selectTeamMemberLabel
            // 
            selectTeamMemberLabel.Font = new Font("Segoe UI Light", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            selectTeamMemberLabel.ForeColor = SystemColors.MenuHighlight;
            selectTeamMemberLabel.Location = new Point(25, 215);
            selectTeamMemberLabel.Name = "selectTeamMemberLabel";
            selectTeamMemberLabel.Size = new Size(321, 47);
            selectTeamMemberLabel.TabIndex = 17;
            selectTeamMemberLabel.Text = "Select Team Member";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(createMemberButton);
            groupBox1.Controls.Add(cellphoneValue);
            groupBox1.Controls.Add(cellphoneLabel);
            groupBox1.Controls.Add(emailValue);
            groupBox1.Controls.Add(emailLabel);
            groupBox1.Controls.Add(lastNameValue);
            groupBox1.Controls.Add(lastNameLabel);
            groupBox1.Controls.Add(firstNameValue);
            groupBox1.Controls.Add(firstNameLabel);
            groupBox1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = SystemColors.MenuHighlight;
            groupBox1.Location = new Point(25, 421);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(537, 435);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add New Member";
            // 
            // createMemberButton
            // 
            createMemberButton.FlatAppearance.BorderColor = Color.Silver;
            createMemberButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 102, 102);
            createMemberButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(242, 242, 242);
            createMemberButton.FlatStyle = FlatStyle.Flat;
            createMemberButton.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createMemberButton.ForeColor = SystemColors.MenuHighlight;
            createMemberButton.Location = new Point(96, 359);
            createMemberButton.Name = "createMemberButton";
            createMemberButton.Size = new Size(291, 51);
            createMemberButton.TabIndex = 21;
            createMemberButton.Text = "Create Member";
            createMemberButton.UseVisualStyleBackColor = true;
            createMemberButton.Click += createMemberButton_Click;
            // 
            // cellphoneValue
            // 
            cellphoneValue.Location = new Point(199, 278);
            cellphoneValue.Name = "cellphoneValue";
            cellphoneValue.Size = new Size(306, 51);
            cellphoneValue.TabIndex = 28;
            // 
            // cellphoneLabel
            // 
            cellphoneLabel.Font = new Font("Segoe UI Light", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cellphoneLabel.ForeColor = SystemColors.MenuHighlight;
            cellphoneLabel.Location = new Point(19, 274);
            cellphoneLabel.Name = "cellphoneLabel";
            cellphoneLabel.Size = new Size(174, 47);
            cellphoneLabel.TabIndex = 27;
            cellphoneLabel.Text = "Cellphone";
            cellphoneLabel.Click += cellphoneLabel_Click;
            // 
            // emailValue
            // 
            emailValue.Location = new Point(199, 203);
            emailValue.Name = "emailValue";
            emailValue.Size = new Size(306, 51);
            emailValue.TabIndex = 26;
            // 
            // emailLabel
            // 
            emailLabel.Font = new Font("Segoe UI Light", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailLabel.ForeColor = SystemColors.MenuHighlight;
            emailLabel.Location = new Point(19, 199);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(174, 47);
            emailLabel.TabIndex = 25;
            emailLabel.Text = "Email";
            // 
            // lastNameValue
            // 
            lastNameValue.Location = new Point(199, 130);
            lastNameValue.Name = "lastNameValue";
            lastNameValue.Size = new Size(306, 51);
            lastNameValue.TabIndex = 24;
            // 
            // lastNameLabel
            // 
            lastNameLabel.Font = new Font("Segoe UI Light", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lastNameLabel.ForeColor = SystemColors.MenuHighlight;
            lastNameLabel.Location = new Point(19, 126);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(174, 47);
            lastNameLabel.TabIndex = 23;
            lastNameLabel.Text = "Last Name";
            // 
            // firstNameValue
            // 
            firstNameValue.Location = new Point(199, 55);
            firstNameValue.Name = "firstNameValue";
            firstNameValue.Size = new Size(306, 51);
            firstNameValue.TabIndex = 22;
            // 
            // firstNameLabel
            // 
            firstNameLabel.Font = new Font("Segoe UI Light", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            firstNameLabel.ForeColor = SystemColors.MenuHighlight;
            firstNameLabel.Location = new Point(19, 51);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(174, 47);
            firstNameLabel.TabIndex = 21;
            firstNameLabel.Text = "First Name";
            // 
            // teamMembersListBox
            // 
            teamMembersListBox.BorderStyle = BorderStyle.FixedSingle;
            teamMembersListBox.FormattingEnabled = true;
            teamMembersListBox.ItemHeight = 37;
            teamMembersListBox.Location = new Point(601, 141);
            teamMembersListBox.Name = "teamMembersListBox";
            teamMembersListBox.Size = new Size(429, 705);
            teamMembersListBox.TabIndex = 21;
            // 
            // deleteSelectedMemberButton
            // 
            deleteSelectedMemberButton.FlatAppearance.BorderColor = Color.Silver;
            deleteSelectedMemberButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 102, 102);
            deleteSelectedMemberButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(242, 242, 242);
            deleteSelectedMemberButton.FlatStyle = FlatStyle.Flat;
            deleteSelectedMemberButton.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deleteSelectedMemberButton.ForeColor = SystemColors.MenuHighlight;
            deleteSelectedMemberButton.Location = new Point(1075, 421);
            deleteSelectedMemberButton.Name = "deleteSelectedMemberButton";
            deleteSelectedMemberButton.Size = new Size(145, 93);
            deleteSelectedMemberButton.TabIndex = 22;
            deleteSelectedMemberButton.Text = "Delete Selected";
            deleteSelectedMemberButton.UseVisualStyleBackColor = true;
            // 
            // createTeamButton
            // 
            createTeamButton.FlatAppearance.BorderColor = Color.Silver;
            createTeamButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 102, 102);
            createTeamButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(242, 242, 242);
            createTeamButton.FlatStyle = FlatStyle.Flat;
            createTeamButton.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createTeamButton.ForeColor = SystemColors.MenuHighlight;
            createTeamButton.Location = new Point(494, 896);
            createTeamButton.Name = "createTeamButton";
            createTeamButton.Size = new Size(291, 51);
            createTeamButton.TabIndex = 29;
            createTeamButton.Text = "Create Team";
            createTeamButton.UseVisualStyleBackColor = true;
            // 
            // CreateTeamForm
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1241, 991);
            Controls.Add(createTeamButton);
            Controls.Add(deleteSelectedMemberButton);
            Controls.Add(teamMembersListBox);
            Controls.Add(groupBox1);
            Controls.Add(addMemberButton);
            Controls.Add(selectTeamMemberDropDown);
            Controls.Add(selectTeamMemberLabel);
            Controls.Add(teamNameValue);
            Controls.Add(teamNameLabel);
            Controls.Add(headerLabel);
            Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(6);
            Name = "CreateTeamForm";
            Text = "Create Team";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox teamNameValue;
        private Label teamNameLabel;
        private Label headerLabel;
        private Button addMemberButton;
        private ComboBox selectTeamMemberDropDown;
        private Label selectTeamMemberLabel;
        private GroupBox groupBox1;
        private TextBox firstNameValue;
        private Label firstNameLabel;
        private TextBox lastNameValue;
        private Label lastNameLabel;
        private TextBox cellphoneValue;
        private Label cellphoneLabel;
        private TextBox emailValue;
        private Label emailLabel;
        private Button createMemberButton;
        private ListBox teamMembersListBox;
        private Button deleteSelectedMemberButton;
        private Button createTeamButton;
    }
}