using BussinessLayer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIS_Desktop
{
    public partial class NewEvent : Form
    {
        AkceServices ac;

        public NewEvent()
        {
            InitializeComponent();
            ac = new AkceServices();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            btnAccept.Enabled = false;
            errorLabel.Visible = false;
            if(textBoxEventName.Text.Length > 0 && textBoxResponsible.Text.Length > 0)
            {
                if (ac.checkNewEvent(textBoxEventName.Text, dateTimePicker.Value, textBoxResponsible.Text, Convert.ToInt32(numericUpDownPrice.Value), 0))
                {
                    btnAccept.Enabled = true;
                }
                else
                {
                    errorLabel.Text = "Date is colliding with another event";
                    errorLabel.Visible = true;
                }

            }
            else if(textBoxResponsible.Text.Length <= 0)
            {
                errorLabel.Text = "Enter Event Name and Responsible Person";
                errorLabel.Visible = true;
            }

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (ac.NewEvent())
            {
                this.Close();
            }
            else
            {
                errorLabel.Text = "Unable to save new event";
                errorLabel.Visible = true;
            }
        }
    }
}
