using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS_Desktop.DTO
{
    public class Vedouci
    {
        public int vid { set; get; }
        public String Jmeno { set; get; }
        public String Pw { get; }
        public DateTime DatumN { set; get; }
        public String Kontakt { set; get; }

        public Vedouci(int vid, string jmeno, string pw, DateTime datumN, string kontakt)
        {
            this.vid = vid;
            this.Jmeno = jmeno;
            this.Pw = pw;
            this.DatumN = datumN;
            this.Kontakt = kontakt;
        }
    }
}
