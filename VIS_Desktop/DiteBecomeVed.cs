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
    public partial class DiteBecomeVed : Form
    {
        DetiServices ds;
        private int id;
        List<DTO.Deti> all;

        public DiteBecomeVed()
        {

            this.ds = new DetiServices();
            this.all = ds.GetAll();

            InitializeComponent();

            for (int i = 0; i < all.Count(); i++)
            {
                if(all[i].Stav == 0)
                {
                    comboBoxDeti.Items.Add(all[i].Jmeno);
                }
            }
        }

        private void comboBoxDeti_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = all.Count();
            MessageBox.Show("Z nejakeho duvodu mi tato funkce bez tohoto vyskakovaciho okna neprobehne a s nim to funguje...");
            for (int i = 0; i < count; i++)
            {
                if (all[i].Jmeno == comboBoxDeti.SelectedText)
                {
                    this.id = all[i].Did;
                    break;
                }
            }
        }

        private void btnDo_Click(object sender, EventArgs e)
        {
            if (this.id != 0)
                ds.DiteBecomeVedouci(this.id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
