using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS_Desktop.DTO
{
    public class Akce
    {
        public Akce(int aid, string Nazev, DateTime DatumK, int? Cena, Vedouci VedouciA, Hodnosti HodnostiA)
        {
            this.aid = aid;
            this.Nazev = Nazev;
            this.DatumK = DatumK;
            this.Cena = Cena;
            this.VedouciA = VedouciA;
            this.HodnostiA = HodnostiA;
        }

        public int aid { get; set; }
        public String Nazev { get; set; }
        public DateTime DatumK { get; set; }
        public int? Cena { get; set; }
        public Vedouci VedouciA { get; set; }
        public Hodnosti HodnostiA { get; set; }
    }
}
