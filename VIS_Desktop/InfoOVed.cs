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
    public partial class InfoOVed : Form
    {
        VedouciServices vs;
        private int id;
        List<DTO.Vedouci> all;

        public InfoOVed()
        {

            vs = new VedouciServices();
            this.all = vs.GetAll();

            InitializeComponent();

            for(int i = 0; i< all.Count(); i++)
            {
                comboBoxVed.Items.Add(all[i].Jmeno);
            }
        }

        private void btnDo_Click(object sender, EventArgs e)
        {
            listBoxVed.Items.Clear();
            var res = vs.VedouciSchuzkaDite(this.id);
            //MessageBox.Show(this.id.ToString());
            if(res!=null)
                listBoxVed.Items.Add(res.Item1 + "\t" + res.Item2 + "\t" + res.Item3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxVed_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("allcount: " + all.Count);
            int count = all.Count();
            MessageBox.Show("Funkce ma informace v db zatim jen o Gelnar Jakub, Hornicek Jiri, Barbora Blazkova a Ondrej Besta ostatni vstupy nic neukazou");
            for(int i = 0; i< count; i++)
            {

                if(all[i].Jmeno == comboBoxVed.SelectedText)
                {
                    this.id = all[i].Vid;
                    break;
                }
            }
            //MessageBox.Show("Vybrane Id: " + this.id);
        }
    }
}
