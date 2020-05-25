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
        MainForm mf;

        public NewEvent(MainForm mainForm)
        {
            InitializeComponent();
            ac = new AkceServices();
            vs = new VedouciServices();
            mf = mainForm;

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
            int currHodnost = 1;
            if (comboBoxRankRestriction.Text.Length > 0)
            {
                currHodnost = comboBoxRankRestriction.SelectedIndex + 1;
            }
            if (textBoxEventName.Text.Length > 0)
            {
                if (ac.checkNewEvent(textBoxEventName.Text, dateTimePicker.Value, comboBoxResponsible.Text, Convert.ToInt32(numericUpDownPrice.Value), currHodnost) == "true" )
                {
                    errorLabel.Text = dateTimePicker.Value.ToString() + ":" + comboBoxResponsible.Text + ":" + currHodnost;
                    //errorLabel.Visible = true;
                    btnAccept.Enabled = true;
                }
                else
                {
                    errorLabel.Text = "Datum koliduje s následujicím eventem v DB: " + ac.checkNewEvent(textBoxEventName.Text, dateTimePicker.Value, comboBoxResponsible.Text, Convert.ToInt32(numericUpDownPrice.Value), currHodnost);
                    errorLabel.Visible = true;
                }

            }
            else if(comboBoxResponsible.Text.Length <= 0 || comboBoxRankRestriction.Text.Length <= 0)
            {
                errorLabel.Text = "Název a Odpovědný vedoucí nesmí být prázdné!";
                errorLabel.Visible = true;
            }

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (ac.NewEvent())
            {
                this.mf.refreshListBox();
                this.mf.refreshSignedOn();
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
