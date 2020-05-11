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
    public partial class NejAkce : Form
    {
        DetiServices ac = new DetiServices();
        List<Tuple<int, string, int, int>> items;
        public NejAkce()
        {
            InitializeComponent();
            items = ac.NejpocetnejsiAkce();
            foreach (Tuple<int, string, int, int> item in items)
            {
                listBoxDeti.Items.Add(item.Item1 + "\t" + item.Item2 + "\t" + item.Item3 + "\t" + item.Item4);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
