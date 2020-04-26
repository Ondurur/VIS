using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS_Desktop.DTO
{
    public class Akce
    {
        public Akce(int aid, string Nazev, DateTime datum_konani, int? Cena, Vedouci vedouci_vid, Hodnosti hodnosti_hid, int? max_pocet_deti)
        {
            this.Aid = aid;
            this.Nazev = Nazev;
            this.Datum_konani = datum_konani;
            this.Cena = Cena;
            this.Max_pocet_deti = max_pocet_deti;
            this.Vedouci_vid = vedouci_vid;
            this.Hodnosti_hid = hodnosti_hid;
        }

        public int Aid { get; set; }
        public String Nazev { get; set; }
        public DateTime Datum_konani { get; set; }
        public int? Cena { get; set; }
        public int? Max_pocet_deti { get; set; }
        public Vedouci Vedouci_vid { get; set; }
        public Hodnosti Hodnosti_hid { get; set; }
    }
}
