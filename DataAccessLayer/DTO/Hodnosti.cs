using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS_Desktop.DTO
{
    public class Hodnosti
    {
        public Hodnosti(int hid, string nazev, int minVek)
        {
            this.hid = hid;
            Nazev = nazev;
            MinVek = minVek;
        }

        public int hid { set; get; }
        public String Nazev { set; get; }
        public int MinVek { set; get; }
    }
}
