using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS_Desktop.DTO
{
    public class Log
    {
        public int Lid { set; get; }
        public int Pocet_deti { set; get; }
        public int Pocet_vedoucich { set; get; }
        public DateTime Datum_zalohy { set; get; }
        public Vedouci Vedouci_vid { set; get; }

        public Log(int lid, int pocetD, int pocetV, DateTime datumZ, Vedouci vedouciL)
        {
            this.Lid = lid;
            this.Pocet_deti = pocetD;
            this.Pocet_vedoucich = pocetV;
            this.Datum_zalohy = datumZ;
            this.Vedouci_vid = vedouciL;
        }
    }
}
