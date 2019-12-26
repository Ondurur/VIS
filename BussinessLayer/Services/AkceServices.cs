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
        List<Akce> all;
        public int[] IDs;
        public string[] names;
        public DateTime[] dateTimes;
        public string[] resp;
        public int[] prices;
        public int[] restricts;

        public AkceServices()
        {
            adm = new AkceDataMapper();
            all = adm.SelectAll();
            IDs = new int[all.Count];
            names = new string[all.Count];
            dateTimes = new DateTime[all.Count];
            resp = new string[all.Count];
            prices = new int[all.Count];
            restricts = new int[all.Count];

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

        public bool NewEvent(string Name, DateTime dateTime, string Responsible, int Price, int Restrict)
        {
            return true;
        }
    }
}
