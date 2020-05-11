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
        public int id;
        private String Role = "Administrator";
        AkceServices ac;

        public MainForm(Login l, int id)
        {
            InitializeComponent();

            this.id = id;

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
            refreshSignedOn();
            foreach (object Item in eventsListBox.CheckedItems)
            {
                bool Possible = true;
                foreach (object RegisteredItem in checkedListBoxSignedOn.CheckedItems)
                {
                    if(Item == RegisteredItem)
                    {
                        Possible = false;
                    }
                    if (!ac.checkDateCollision(Item, RegisteredItem))
                    {
                        Possible = false;
                    }
                }
                if (Possible)
                {
                    ac.SignMeOnEvent(Int32.Parse(Item.ToString().Substring(0, Item.ToString().IndexOf("\t"))), this.id);
                }
            }
            refreshListBox();
            refreshSignedOn();
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
            List<int> signedOn = ac.getSignedOn(this.id);
            for(int i = 0; i< signedOn.Count; i++)
            {
                foreach(var akce in ac.all)
                {
                    if(akce.Aid == signedOn.ElementAt(i))
                    {
                        checkedListBoxSignedOn.Items.Add(akce.Aid + "\t" + akce.Nazev + "\t"  + (akce.Cena == null ? akce.Cena : 0) + "\t" + akce.Datum_konani.ToString());
                    }
                }
            }
        }

        private void btnRemovePerson_Click(object sender, EventArgs e)
        {
            string checkedItems = string.Empty;
            foreach (object Item in checkedListBoxSignedOn.CheckedItems)
            {
                int itemId = Int32.Parse(Item.ToString().Substring(0, Item.ToString().IndexOf("\t")));
                ac.RemoveFromEvent(itemId, this.id);
            }
            //MessageBox.Show(checkedItems);
            refreshSignedOn();
        }

        private void btnCSVExport_Click(object sender, EventArgs e)
        {
            string checkedItems = string.Empty;
            foreach (object Item in checkedListBoxSignedOn.CheckedItems)
            {
                checkedItems += Item.ToString() + "\n";
            }
            if (ac.ExportCSV(checkedItems))
            {
                MessageBox.Show("Successfuly Exported!");
            }
            else
            {
                MessageBox.Show("An error occurred!");
            }
            
        }

        private void btnCustomSQL_Click(object sender, EventArgs e)
        {
            for(int i = 0; i<5; i++)
            {
                ac.Save();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void labelSigned_Click(object sender, EventArgs e)
        {

        }

        private void btnDiteBecomeVed_Click(object sender, EventArgs e)
        {
            DiteBecomeVed dbv = new DiteBecomeVed();
            dbv.Show();
        }

        private void btnInfoOVed_Click(object sender, EventArgs e)
        {
            InfoOVed iov = new InfoOVed();
            iov.Show();
        }

        private void btnNejAkce_Click(object sender, EventArgs e)
        {
            NejAkce na = new NejAkce();
            na.Show();
        }
    }
}
