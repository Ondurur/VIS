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
    public partial class MainForm : Form
    {
        public String username;
        private String Role = "Administrator";

        public MainForm(Login l)
        {
            InitializeComponent();
            this.username = l.username;
            labelSigned.Text = "Signed as: " + this.username;
            labelRole.Text = "Role: " + Role;
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
    }
}
