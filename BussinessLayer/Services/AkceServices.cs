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
        List<Akce> all;
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
                IDs[i] = all.ElementAt(i).aid;
                names[i] = all.ElementAt(i).Nazev;
                dateTimes[i] = all.ElementAt(i).DatumK;
                resp[i] = all.ElementAt(i).VedouciA.Jmeno;
                prices[i] = all.ElementAt(i).Cena;
                restricts[i] = all.ElementAt(i).HodnostiA.hid;
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
            newEvent = new Akce(adm.SelectAll().Count, Name, dateTime, Price, vdm.SelectByName(Responsible), hdm.SelectById(Restrict), "");
            return true;
        }

        public bool NewEvent()
        {
            adm.Save(newEvent);
            return true;
        }

        public bool SignMeOnEvent(string events, string Name)
        {
            string length = events.Replace(";", "");
            int[] IDs = new int[events.Length];
            int j = 0;
            string temp = "";
            for (int i = 0; i<IDs.Length; i++)
            {

                if(events[i] == ';')
                {
                    IDs[j] = int.Parse(temp);
                    j++;
                    temp = "";
                }
                else
                {
                    temp += events[i];
                }
            }

            for(int i = 0; i< IDs.Length; i++)
            {
                Akce tempAkce = adm.SelectById(IDs[i]);
                tempAkce.detiList += Name + ";";
                adm.Save(tempAkce);
            }
            return true;
        }

        public void removeFromEvent(string events,string username)
        {
            string length = events.Replace(";", "");
            int[] IDs = new int[events.Length];
            int j = 0;
            string temp = "";
            for (int i = 0; i < IDs.Length; i++)
            {

                if (events[i] == ';')
                {
                    IDs[j] = int.Parse(temp);
                    j++;
                    temp = "";
                }
                else
                {
                    temp += events[i];
                }
            }
            for (int i = 0; i < IDs.Length; i++)
            {
                Akce tempAkce = adm.SelectById(IDs[i]);
                tempAkce.detiList.Replace(username + ";", "");
                adm.Save(tempAkce);
            }

        }

        public List<string> getSignedOn(string username)
        {
            List<string> ret = new List<string>();
            foreach(Akce a in all)
            {
                int count = 0;
                foreach (char c in a.detiList)
                    if (c == ';') count++;
                for (int i = 0; i<count; i++)
                {
                    int index = a.detiList.IndexOf(';');
                    if (username == a.detiList.Substring(0, index))
                    {
                        ret.Add(a.aid + "\t" + a.Nazev + "\t" + a.Cena + "\t" + a.DatumK.ToString());
                    }
                    else
                    {
                        a.detiList = a.detiList.Substring(index+1);
                    }
                }
            }
            return ret;
        }

        public void Save()
        {
            for(int i = 0; i< 5; i++)
            {
                Akce temp = all.ElementAt(i);
                temp.detiList = "";
                adm.Save(temp);
            }
        }
    }
}
