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
    public partial class Login : Form
    {
        public String username;
        private String pw;
        public int id;

        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.username = textBox1.Text;
            this.pw = textBox2.Text;
            if (!checkBoxCSV.Checked)
            {
                if (loginSuccessfullDB(username, pw))
                {
                    this.Hide();
                }
                else
                {
                    label3.Visible = true;
                }
            }
            else
            {

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private bool loginSuccessfullDB(string username, string pw)
        {
            DetiServices ds = new DetiServices();
            VedouciServices vs = new VedouciServices();
            Tuple<int, string, string> l;
            l = ds.LoginAs(username, pw);
            if (l !=null)
            {
                
                this.username = l.Item2;
                int id = l.Item1;
                MainForm mf = new MainForm(this, id);
                mf.Activate();
                mf.Show();
                mf.labelSigned.Text = "Signed as: " + ds.LoginAs(username,pw).Item2;
                mf.labelRole.Text = "Role: " + ds.LoginAs(username,pw).Item3;

                return true;
            }
            l = vs.LoginAs(username, pw);
            if (l != null)
            {
                int id = l.Item1;
                MainForm mf = new MainForm(this, id);
                mf.Activate();
                mf.Show();
                mf.labelSigned.Text = "Signed as: " + username;
                mf.labelRole.Text = "Role: Admin";

                return true;
            }


            return false;
        }

        private bool loginSuccessfullCSV(string username, string pw)
        {
            return false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label3.Visible = false;
        }
    }
}
