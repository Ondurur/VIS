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
        AkceDetiDataMapper addm;
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
            addm = new AkceDetiDataMapper();

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

        public string checkNewEvent(string Name, DateTime dateTime, string Responsible, int Price, int Restrict)
        {
            newEvent = null;
            for (int i = 0; i < dateTimes.Length; i++)
            {
                if (dateTime.DayOfYear == dateTimes[i].DayOfYear && dateTime.Year == dateTimes[i].Year)
                {
                    return names[i] + ">" + dateTime.DayOfYear + ":" + dateTimes[i].DayOfYear + "&&" + dateTime.Year + ":" + dateTimes[i].Year;
                }
            }
            newEvent = new Akce(adm.SelectAll().Count + 1, Name, dateTime, Price, vdm.SelectByName(Responsible), hdm.SelectById(Restrict), 300);
            return "true";
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

            if (prvni == druhy)
            {
                return false;
            }
            return true;
        }

        public bool NewEvent()
        {
            adm.Insert(newEvent);
            return true;
        }

        public bool SignMeOnEvent(int aid, int did)
        {
            addm.AddAkceToDite(did, aid);
            return true;
        }

        public bool RemoveFromEvent(int aid, int did)
        {
            addm.Delete(aid, did);
            return true;
        }

        public List<int> getSignedOn(int did)
        {
            List<AkceDeti> tmp = addm.SelectByDetiId(did);
            List<int> ret = new List<int>();

            for(int i = 0; i< tmp.Count(); i++)
            {
                ret.Add(tmp[i].Akce_aid);
            }
            return ret;
        }

        public void Save()
        {
            /*for (int i = 0; i < 5; i++)
            {
                Akce temp = all.ElementAt(i);
                temp.detiList = "";
                adm.Save(temp);
            }*/
            return;
        }

        public bool ExportCSV(string lines)
        {
            try
            {
                Logger l = Logger.GetLogger();
                l.WriteMessage(lines);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Hodnosti> GetHodnosti()
        {
            return hdm.SelectAll();
        }
    }
}
