using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS_Desktop.DTO
{
    public class DetiArchiv
    {

        public DetiArchiv(int id, string Jmeno, DateTime DatumN, string kontaktNR, Deti archivD)
        {
            this.did = id;
            this.Jmeno = Jmeno;
            this.DatumN = DatumN;
            this.kontaktNR = kontaktNR;
            this.archivD = archivD;
        }

        public int did { set; get; }
        public String Jmeno { set; get; }
        public DateTime DatumN { set; get; }
        public String kontaktNR { set; get; }
        public Deti archivD { set; get; }
    }
}
