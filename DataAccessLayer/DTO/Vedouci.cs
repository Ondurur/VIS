using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS_Desktop.DTO
{
    public class Vedouci
    {
        public int Vid { set; get; }
        public String Jmeno { set; get; }
        public String Heslo { get; }
        public DateTime Datum_narozeni { set; get; }
        public String Kontakt { set; get; }
        public Funkce Funkce_fid { get; set; }

        public Vedouci(int vid, string jmeno, string heslo, DateTime datum_narozeni, string kontakt, Funkce funkce)
        {
            this.Vid = vid;
            this.Jmeno = jmeno;
            this.Heslo = heslo;
            this.Datum_narozeni = datum_narozeni;
            this.Kontakt = kontakt;
            this.Funkce_fid = funkce;
        }
    }
}
