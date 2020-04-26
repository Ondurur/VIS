using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS_Desktop.DTO
{
    public class Hodnosti
    {
        public Hodnosti(int hid, string nazev, int minimalni_vek)
        {
            this.Hid = hid;
            this.Nazev = nazev;
            this.Minimalni_vek = minimalni_vek;
        }

        public int Hid { set; get; }
        public String Nazev { set; get; }
        public int Minimalni_vek { set; get; }
    }
}
