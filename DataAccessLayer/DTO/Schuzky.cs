using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS_Desktop.DTO
{
    public class Schuzky
    {
        public Schuzky(int sid, string nazev, int pocet_Deti, int datum_konani,  Vedouci vedouci_vid)
        {
            this.Sid = sid;
            this.Nazev = nazev;
            this.Datum_konani = datum_konani;
            this.Pocet_Deti = pocet_Deti;
            this.Vedouci_vid = vedouci_vid;
        }

        public int Sid { set; get; }
        public String Nazev { set; get; }
        public int Pocet_Deti { set; get; }
        public int Datum_konani { set; get; }
        public Vedouci Vedouci_vid { set; get; }
    }
}
