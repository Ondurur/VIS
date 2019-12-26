using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS_Desktop.DTO
{
    public class AkceArchiv
    {
        public AkceArchiv(int aid, string Nazev, DateTime DatumK, int Cena, Akce archivA)
        {
            this.aid = aid;
            this.Nazev = Nazev;
            this.DatumK = DatumK;
            this.Cena = Cena;
            this.archivA = archivA;
        }

        public int aid { get; set; }
        public String Nazev { get; set; }
        public DateTime DatumK { get; set; }
        public int? Cena { get; set; }
        public Akce archivA { get; set; }
    }
}
