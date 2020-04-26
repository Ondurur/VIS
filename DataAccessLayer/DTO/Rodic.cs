using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS_Desktop.DTO
{
    public class Rodic
    {

        public Rodic(int id, string Jmeno, string login, string heslo, string kontakt)
        {
            this.Rid = id;
            this.Jmeno = Jmeno;
            this.Login = login;
            this.Heslo = heslo;
            this.Kontakt = kontakt;
        }

        public int Rid { set; get; }
        public String Jmeno { set; get; }
        public String Login { set; get; }
        public String Heslo { set; get; }
        public String Kontakt { set; get; }
    }
}
