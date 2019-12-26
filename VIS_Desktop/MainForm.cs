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
            ac = new AkceServices();

            InitializeComponent();
            this.username = l.username;
            labelSigned.Text = "Signed as: " + this.username;
            labelRole.Text = "Role: " + Role;
            for(int i = 0; i<ac.IDs.Length; i++)
            {
                eventsListBox.Items.Add(ac.IDs[i] + " " + ac.names[i] + " " + ac.prices[i] + " " + ac.dateTimes[i].ToString());
            }
            switch (Role)
            {
                case "Administrator":
                    btnAddEvent.Visible = true;
                    break;

                case "Parent":
                    break;

                case "Child":
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
                checkedItems += Item.ToString();
            }
            MessageBox.Show(checkedItems);
        }
    }
}
