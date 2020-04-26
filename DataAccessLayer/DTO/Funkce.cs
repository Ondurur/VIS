using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS_Desktop.DTO
{
    public class Funkce
    {
        public Funkce(int fid, string nazev, string povinnosti)
        {
            this.Fid = fid;
            this.Nazev = nazev;
            this.Povinnosti = povinnosti;
        }

        public int Fid { set; get; }
        public String Nazev { set; get; }
        public String Povinnosti { set; get; }
    }
}
