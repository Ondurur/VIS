using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIS_Desktop.DataAccessLayer.DataMappers;
using VIS_Desktop.DTO;

namespace BussinessLayer.Services
{
    public class DetiServices
    {
        DetiDataMapper detiDataMapper;

        public DetiServices()
        {
            detiDataMapper = new DetiDataMapper();
        }

        public Tuple<int,string,string>/*<id,nick,role>*/ LoginAs(string username, string pw)
        {
            Deti d = null;
            int role;
            d = detiDataMapper.TryLogin(username, pw);

            if (d.Nickname == username)
            {
                role = 1;
            }
            else
            {
                role = 0;
            }

            if (d != null && role == 0)
            {
                return new Tuple<int, string, string>(d.did, d.Jmeno, "Child");
            }
            else if(d!= null && role == 1)
            {
                return new Tuple<int, string, string>(d.did, d.Jmeno, "Parent");
            }
            return null;
        }

        public bool SaveDite(int did, string jmeno, string pw, string nickname, DateTime datumN, string kontaktNR, int hodnostD, int schuzkyD)
        {
            DetiDataMapper ddm = new DetiDataMapper();
            return true;
        }

    }
}
