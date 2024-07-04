namespace TrackerUI
{
    partial class CreatePrizeForm
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
            headerLabel = new Label();
            placeNumberValue = new TextBox();
            placeNumberLabel = new Label();
            placeNameValue = new TextBox();
            placeNameLabel = new Label();
            prizeAmountValue = new TextBox();
            prizeAmountLabel = new Label();
            prizePercentageValue = new TextBox();
            prizePercentageLabel = new Label();
            orLabel = new Label();
            createPrizeButton = new Button();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI Light", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            headerLabel.ForeColor = SystemColors.MenuHighlight;
            headerLabel.Location = new Point(28, 25);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(267, 62);
            headerLabel.TabIndex = 12;
            headerLabel.Text = "Create Prize";
            // 
            // placeNumberValue
            // 
            placeNumberValue.Location = new Point(316, 113);
            placeNumberValue.Name = "placeNumberValue";
            placeNumberValue.Size = new Size(306, 43);
            placeNumberValue.TabIndex = 24;
            // 
            // placeNumberLabel
            // 
            placeNumberLabel.Font = new Font("Segoe UI Light", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            placeNumberLabel.ForeColor = SystemColors.MenuHighlight;
            placeNumberLabel.Location = new Point(76, 109);
            placeNumberLabel.Name = "placeNumberLabel";
            placeNumberLabel.Size = new Size(234, 47);
            placeNumberLabel.TabIndex = 23;
            placeNumberLabel.Text = "Place Number";
            placeNumberLabel.Click += placeNumberLabel_Click;
            // 
            // placeNameValue
            // 
            placeNameValue.Location = new Point(316, 189);
            placeNameValue.Name = "placeNameValue";
            placeNameValue.Size = new Size(306, 43);
            placeNameValue.TabIndex = 26;
            // 
            // placeNameLabel
            // 
            placeNameLabel.Font = new Font("Segoe UI Light", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            placeNameLabel.ForeColor = SystemColors.MenuHighlight;
            placeNameLabel.Location = new Point(76, 185);
            placeNameLabel.Name = "placeNameLabel";
            placeNameLabel.Size = new Size(234, 47);
            placeNameLabel.TabIndex = 25;
            placeNameLabel.Text = "Place Name";
            // 
            // prizeAmountValue
            // 
            prizeAmountValue.Location = new Point(316, 265);
            prizeAmountValue.Name = "prizeAmountValue";
            prizeAmountValue.Size = new Size(306, 43);
            prizeAmountValue.TabIndex = 28;
            // 
            // prizeAmountLabel
            // 
            prizeAmountLabel.Font = new Font("Segoe UI Light", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            prizeAmountLabel.ForeColor = SystemColors.MenuHighlight;
            prizeAmountLabel.Location = new Point(76, 261);
            prizeAmountLabel.Name = "prizeAmountLabel";
            prizeAmountLabel.Size = new Size(234, 47);
            prizeAmountLabel.TabIndex = 27;
            prizeAmountLabel.Text = "Prize Amount";
            // 
            // prizePercentageValue
            // 
            prizePercentageValue.Location = new Point(330, 416);
            prizePercentageValue.Name = "prizePercentageValue";
            prizePercentageValue.Size = new Size(306, 43);
            prizePercentageValue.TabIndex = 30;
            // 
            // prizePercentageLabel
            // 
            prizePercentageLabel.Font = new Font("Segoe UI Light", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            prizePercentageLabel.ForeColor = SystemColors.MenuHighlight;
            prizePercentageLabel.Location = new Point(76, 413);
            prizePercentageLabel.Name = "prizePercentageLabel";
            prizePercentageLabel.Size = new Size(264, 47);
            prizePercentageLabel.TabIndex = 29;
            prizePercentageLabel.Text = "Prize Percentage";
            // 
            // orLabel
            // 
            orLabel.Font = new Font("Segoe UI Light", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            orLabel.ForeColor = SystemColors.MenuHighlight;
            orLabel.Location = new Point(295, 338);
            orLabel.Name = "orLabel";
            orLabel.Size = new Size(101, 47);
            orLabel.TabIndex = 31;
            orLabel.Text = "- or -";
            // 
            // createPrizeButton
            // 
            createPrizeButton.FlatAppearance.BorderColor = Color.Silver;
            createPrizeButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 102, 102);
            createPrizeButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(242, 242, 242);
            createPrizeButton.FlatStyle = FlatStyle.Flat;
            createPrizeButton.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createPrizeButton.ForeColor = SystemColors.MenuHighlight;
            createPrizeButton.Location = new Point(210, 496);
            createPrizeButton.Name = "createPrizeButton";
            createPrizeButton.Size = new Size(291, 51);
            createPrizeButton.TabIndex = 32;
            createPrizeButton.Text = "Create Prize";
            createPrizeButton.UseVisualStyleBackColor = true;
            // 
            // CreatePrizeForm
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(671, 589);
            Controls.Add(createPrizeButton);
            Controls.Add(orLabel);
            Controls.Add(prizePercentageValue);
            Controls.Add(prizePercentageLabel);
            Controls.Add(prizeAmountValue);
            Controls.Add(prizeAmountLabel);
            Controls.Add(placeNameValue);
            Controls.Add(placeNameLabel);
            Controls.Add(placeNumberValue);
            Controls.Add(placeNumberLabel);
            Controls.Add(headerLabel);
            Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(6, 6, 6, 6);
            Name = "CreatePrizeForm";
            Text = "Create Prize";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label headerLabel;
        private TextBox placeNumberValue;
        private Label placeNumberLabel;
        private TextBox placeNameValue;
        private Label placeNameLabel;
        private TextBox prizeAmountValue;
        private Label prizeAmountLabel;
        private TextBox prizePercentageValue;
        private Label prizePercentageLabel;
        private Label orLabel;
        private Button createPrizeButton;
    }
}