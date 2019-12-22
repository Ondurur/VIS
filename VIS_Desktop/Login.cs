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
            
            if (loginSuccessfull(username, pw))
            {
                MainForm mainForm = new MainForm(this);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                label3.Visible = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private bool loginSuccessfull(string username, string pw)
        {
            DetiServices ds = new DetiServices();
            VedouciServices vs = new VedouciServices();

            if(ds.LoginAs(username, pw)!=null)
            {
                MainForm mf = new MainForm(this);
                mf.Show();
                mf.labelSigned.Text = "Signed as: " + username;
                mf.labelRole.Text = "Role: Dite"; 
            }
            if(vs.LoginAs(username, pw) != null)
            {
                MainForm mf = new MainForm(this);
                mf.Show();
                mf.labelSigned.Text = "Signed as: " + username;
                mf.labelRole.Text = "Role: Admin";

            }


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
