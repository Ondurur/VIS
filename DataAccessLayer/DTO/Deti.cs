using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS_Desktop.DTO
{
    public class Deti
    {
        public Deti(int did, string jmeno, string nickname, string pw, DateTime datumN, string kontaktNR, Hodnosti hodnostD, Schuzky schuzkyD)
        {
            this.did = did;
            Jmeno = jmeno;
            Pw = pw;
            Nickname = nickname;
            DatumN = datumN;
            this.KontaktNR = kontaktNR;
            HodnostD = hodnostD;
            SchuzkyD = schuzkyD;
        }

        public int did { set; get; }
        public String Jmeno { set; get; }
        public String Nickname { set; get; }
        public String Pw { set; get; }
        public DateTime DatumN { set; get; }
        public String KontaktNR { set; get; }
        public Hodnosti HodnostD { set; get; }
        public Schuzky SchuzkyD { set; get; }
    }
}
