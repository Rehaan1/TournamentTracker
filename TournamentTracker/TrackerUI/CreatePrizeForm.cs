﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        IPrizeRequester callingForm;

        public CreatePrizeForm()
        {
            InitializeComponent();
        }

        public CreatePrizeForm(IPrizeRequester caller)
        {
            InitializeComponent();

            callingForm = caller;
        }

        private void placeNumberLabel_Click(object sender, EventArgs e)
        {

        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            if(ValidateForm())
            {
                PrizeModel model = new PrizeModel(
                    placeNameValue.Text,
                    placeNumberValue.Text,
                    prizeAmountValue.Text,
                    prizePercentageValue.Text);

                GlobalConfig.Connection.CreatePrize(model);
                
                if(callingForm != null) 
                {
                    callingForm.PrizeComplete(model);
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("This form has invalid information. Please check it and try again.");
            }
        }


        /// <summary>
        /// Validates the form inputs.
        /// </summary>
        /// <returns>
        /// True if the form inputs are valid, false otherwise.
        /// </returns>
        private bool ValidateForm()
        {
            bool output = true;

            int placeNumber = 0;

            if (!int.TryParse(placeNumberValue.Text, out placeNumber))
            {
                output = false;
            }

            if (placeNumber < 1)
            {
                output = false;
            }

            if (placeNameValue.Text.Length == 0)
            {
                output = false;
            }

            decimal prizeAmount = 0;
            double prizePercentage = 0;

            if (!decimal.TryParse(prizeAmountValue.Text, out prizeAmount) ||
                !double.TryParse(prizePercentageValue.Text, out prizePercentage))
            {
                output = false;
            }

            if (prizeAmount <=0 && prizePercentage <= 0)
            {
                output = false;
            }

            if (prizePercentage < 0 || prizePercentage > 100)
            {
                output = false;
            }

            return output;
        }
    }
}
