using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessLayer.Services;

namespace VIS_Desktop
{
    public partial class MainForm : Form
    {
        public String username;
        private String Role = "Administrator";
        AkceServices ac;

        public MainForm(Login l)
        {
            InitializeComponent();
            

            refreshListBox();
            refreshSignedOn();

            this.username = l.username;
            labelSigned.Text = "Signed as: " + this.username;
            labelRole.Text = "Role: " + Role;
            switch (Role)
            {
                case "Administrator":
                    btnAddEvent.Visible = true;
                    btnCustomSQL.Visible = false;
                    break;

                case "Parent":
                    btnCustomSQL.Visible = false;
                    break;

                case "Child":
                    btnChangeInf.Visible = false;
                    btnCustomSQL.Visible = false;
                    break;

                default:
                    break;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            NewEvent nw = new NewEvent();
            nw.Show();
        }

        private void btnEventSignIn_Click(object sender, EventArgs e)
        {
            string checkedItems = string.Empty;
            foreach (object Item in eventsListBox.CheckedItems)
            {
                checkedItems += Item.ToString().Substring(0, Item.ToString().IndexOf("\t")) + ";";
            }
            //MessageBox.Show(checkedItems);
            ac.SignMeOnEvent(checkedItems, username);
            refreshListBox();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshListBox();
            refreshSignedOn();
        }

        public void refreshListBox()
        {
            ac = new AkceServices();
            eventsListBox.Items.Clear();
            for (int i = 0; i < ac.IDs.Length; i++)
            {
                int? price;
                if(ac.prices[i] == null)
                {
                    price = 0;
                }
                else
                {
                    price = ac.prices[i];
                }
                eventsListBox.Items.Add(ac.IDs[i] + "\t" + ac.names[i] + "\t" + price + "\t" + ac.dateTimes[i].ToString());
            }
        }

        public void refreshSignedOn()
        {
            checkedListBoxSignedOn.Items.Clear();
            List<string> signedOn = ac.getSignedOn(username);
            for(int i =0; i< signedOn.Count; i++)
            {
                checkedListBoxSignedOn.Items.Add(signedOn.ElementAt(i));
            }
        }

        private void btnRemovePerson_Click(object sender, EventArgs e)
        {
            string checkedItems = string.Empty;
            foreach (object Item in checkedListBoxSignedOn.CheckedItems)
            {
                checkedItems += Item.ToString().Substring(0, Item.ToString().IndexOf("\t")) + ";";
            }
            MessageBox.Show(checkedItems);
            ac.removeFromEvent(checkedItems, username);
            refreshSignedOn();
        }

        private void btnCSVExport_Click(object sender, EventArgs e)
        {

        }

        private void btnCustomSQL_Click(object sender, EventArgs e)
        {
            for(int i = 0; i<5; i++)
            {
                ac.Save();
            }
        }
    }
}
