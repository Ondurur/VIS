using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS_Desktop.DTO
{
    public class Schuzky
    {
        public Schuzky(int sid, string nazev, int pocetD, int datumK,  Vedouci vedouciS)
        {
            this.sid = sid;
            this.Nazev = nazev;
            this.DatumK = datumK;
            this.PocetD = pocetD;
            this.VedouciS = vedouciS;
        }

        public int sid { set; get; }
        public String Nazev { set; get; }
        public int PocetD { set; get; }
        public int DatumK { set; get; }
        public Vedouci VedouciS { set; get; }
    }
}
