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
        public NewEvent()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if(textBoxEventName.Text.Length > 0 && textBoxResponsible.Text.Length > 0)
            {

            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

        }
    }
}
