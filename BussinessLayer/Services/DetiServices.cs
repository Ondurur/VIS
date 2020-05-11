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
            if (d != null)
            {
                if (d.Nickname == username)
                {
                    role = 1;
                }
                else
                {
                    role = 0;
                }

                if (role == 0)
                {
                    return new Tuple<int, string, string>(d.Did, d.Jmeno, "Child");
                }
                else if (role == 1)
                {
                    return new Tuple<int, string, string>(d.Did, d.Jmeno, "Parent");
                }
            }
            return null;
        }

        public List<Tuple<int, string, int, int>> NejpocetnejsiAkce()
        {
            return detiDataMapper.NejpocetnejsiAkce();
        }

        public bool SaveDite(int did, string jmeno, string pw, string nickname, DateTime datumN, string kontaktNR, int hodnostD, int schuzkyD)
        {
            DetiDataMapper ddm = new DetiDataMapper();
            return true;
        }

        public List<Deti> GetAll()
        {
            return detiDataMapper.SelectAll();
        }

        public void DiteBecomeVedouci(int p_dID)
        {
            VedouciDataMapper vdm = new VedouciDataMapper();
            vdm.DiteBecomeVedouci(p_dID);
        }

    }
}
