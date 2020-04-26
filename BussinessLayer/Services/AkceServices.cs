using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIS_Desktop.DataAccessLayer.DataMappers;
using VIS_Desktop.DTO;

namespace BussinessLayer.Services
{
    public class AkceServices
    {
        AkceDataMapper adm;
        VedouciDataMapper vdm;
        HodnostiDataMapper hdm;
        public List<Akce> all;
        public int[] IDs;
        public string[] names;
        public DateTime[] dateTimes;
        public string[] resp;
        public int?[] prices;
        public int[] restricts;
        Akce newEvent;

        public AkceServices()
        {
            adm = new AkceDataMapper();

            all = adm.SelectAll();
            IDs = new int[all.Count];
            names = new string[all.Count];
            dateTimes = new DateTime[all.Count];
            resp = new string[all.Count];
            prices = new int?[all.Count];
            restricts = new int[all.Count];
            vdm = new VedouciDataMapper();
            hdm = new HodnostiDataMapper();

            for (int i = 0; i < all.Count; i++)
            {
                IDs[i] = all.ElementAt(i).Aid;
                names[i] = all.ElementAt(i).Nazev;
                dateTimes[i] = all.ElementAt(i).Datum_konani;
                resp[i] = all.ElementAt(i).Vedouci_vid.Jmeno;
                prices[i] = all.ElementAt(i).Cena;
                Console.Write("yikes");
            }

        }

        public bool checkNewEvent(string Name, DateTime dateTime, string Responsible, int Price, int Restrict)
        {
            bool resp = false;
            for (int i = 0; i < dateTimes.Length; i++)
            {
                if (dateTime.DayOfYear == dateTimes[i].DayOfYear && dateTime.Year == dateTimes[i].Year)
                {
                    return false;
                }
                else if(Responsible == this.resp[i])
                {
                    resp = true;
                }
            }
            if (!resp)
            {
                return resp;
            }
            newEvent = new Akce(adm.SelectAll().Count, Name, dateTime, Price, vdm.SelectByName(Responsible), hdm.SelectById(Restrict), 300);
            return true;
        }

        public bool checkDateCollision(object item, object registeredItem)
        {
            string prvni = item.ToString();
            string druhy = registeredItem.ToString();
            prvni.Reverse();
            druhy.Reverse();
            prvni = prvni.Substring(0, prvni.IndexOf(';'));
            druhy = druhy.Substring(0, druhy.IndexOf(';'));

            prvni.Reverse();
            druhy.Reverse();

            if(prvni == druhy)
            {
                return false;
            }
            return true;
        }

        public bool NewEvent()
        {
            adm.Save(newEvent);
            return true;
        }

        public bool SignMeOnEvent(string events, string Name)
        {
            //string[] IDs = events.Substring(0,events.Length-1).Split(';');

            //for(int i = 0; i< IDs.Length; i++)
            //{
            //    int j = Convert.ToInt32(IDs[i]);
            //    Akce tempAkce = adm.SelectById(j);
            //    tempAkce.detiList += Name + ";";
            //    adm.Save(tempAkce);
            //}
            return true;
        }

        public bool RemoveFromEvent(string events,string Name)
        {
            //string[] IDs = events.Substring(0, events.Length - 1).Split(';');

            //for (int i = 0; i < IDs.Length; i++)
            //{
            //    int j = Convert.ToInt32(IDs[i]);
            //    Akce tempAkce = adm.SelectById(j);
            //    int zacatek = tempAkce.detiList.IndexOf(Name[0]);
            //    string tempStr = tempAkce.detiList.Remove(zacatek, Name.Length);
            //    tempAkce.detiList = tempStr;
            //    adm.Save(tempAkce);
            //}
            return true;
        }

        public List<string> getSignedOn(string username)
        {/*
            List<string> ret = new List<string>();
            foreach (Akce a in all)
            {
                int count = 0;
                foreach (char c in a.detiList)
                    if (c == ';') count++;
                for (int i = 0; i < count; i++)
                {
                    int index = a.detiList.IndexOf(';');
                    if (username == a.detiList.Substring(0, index))
                    {
                        ret.Add(a.aid + "\t" + a.Nazev + "\t" + a.Cena + "\t" + a.datum_konani.ToString());
                    }
                    else
                    {
                        a.detiList = a.detiList.Substring(index + 1);
                    }
                }
            }*/
            return null;
        }

        public void Save()
        {
            //for(int i = 0; i< 5; i++)
            //{
            //    Akce temp = all.ElementAt(i);
            //    temp.detiList = "";
            //    adm.Save(temp);
            //}
        }

        public bool ExportCSV(string lines)
        {
            try
            {
                Logger l = Logger.GetLogger();
                l.WriteMessage(lines);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
