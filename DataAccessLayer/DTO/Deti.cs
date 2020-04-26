using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS_Desktop.DTO
{
    public class Deti
    {
        public Deti(int did, string jmeno, string nickname, string heslo, DateTime datum_narozeni, int stav, Hodnosti hodnosti_hid, Schuzky schuzky_sid, int? reg_akci, Rodic rodic_rid)
        {
            this.Did = did;
            this.Jmeno = jmeno;
            this.Heslo = heslo;
            this.Nickname = nickname;
            this.Datum_narozeni = datum_narozeni;
            this.Stav = stav;
            this.Hodnosti_hid = hodnosti_hid;
            this.Schuzky_sid = schuzky_sid;
            this.Rodic_rid = rodic_rid;
            this.Reg_akci = reg_akci;
        }

        public int Did { set; get; }
        public String Jmeno { set; get; }
        public String Nickname { set; get; }
        public String Heslo { set; get; }
        public DateTime Datum_narozeni { set; get; }
        public int Stav { set; get; }
        public Hodnosti Hodnosti_hid { set; get; }
        public Schuzky Schuzky_sid { set; get; }
        public int? Reg_akci { set; get; }
        public Rodic Rodic_rid { get; set; }
    }
}
