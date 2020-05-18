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
        List<DTO.Vedouci> allResp;
        List<DTO.Hodnosti> allHodn;
        VedouciServices vs; 

        public NewEvent()
        {
            InitializeComponent();
            ac = new AkceServices();
            vs = new VedouciServices();

            this.allResp = vs.GetAll();
            this.allHodn = ac.GetHodnosti();

            comboBoxRankRestriction.Items.Clear();
            comboBoxResponsible.Items.Clear();

            for (int i = 0; i < allResp.Count(); i++)
            {
                comboBoxResponsible.Items.Add(allResp[i].Jmeno);
            }

            for(int i = 0; i < allHodn.Count(); i++)
            {
                comboBoxRankRestriction.Items.Add(allHodn[i].Nazev);
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            btnAccept.Enabled = false;
            errorLabel.Visible = false;
            int currHodnost = comboBoxRankRestriction.SelectedIndex;
            if(textBoxEventName.Text.Length > 0)
            {
                if (ac.checkNewEvent(textBoxEventName.Text, dateTimePicker.Value, comboBoxResponsible.Text, Convert.ToInt32(numericUpDownPrice.Value), currHodnost))
                {
                    btnAccept.Enabled = true;
                }
                else
                {
                    errorLabel.Text = "Date is colliding with another event";
                    errorLabel.Visible = true;
                }

            }
            else if(comboBoxResponsible.Text.Length <= 0)
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
