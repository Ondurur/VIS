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
            
            Deti d = detiDataMapper.TryLogin(username, pw);
            if(d == null)
            {
                return new Tuple<int, string, string>(d.did, d.Jmeno, "Dite");
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
