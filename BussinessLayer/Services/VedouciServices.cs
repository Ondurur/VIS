﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIS_Desktop.DataAccessLayer.DataMappers;
using VIS_Desktop.DTO;

namespace BussinessLayer.Services
{
    public class VedouciServices
    {
        VedouciDataMapper vdm;

        public VedouciServices()
        {
            vdm = new VedouciDataMapper();
        }

        public Tuple<int, string, string>/*<id,nick,role>*/ LoginAs(string username, string pw)
        {
            VedouciDataMapper vdm = new VedouciDataMapper();
            Vedouci d = vdm.TryLogin(username, pw);
            if (d != null)
            {
                return new Tuple<int, string, string>(d.Vid, d.Jmeno, "Administrator");
            }
            return null;
        }

        public Tuple<string, string, string> VedouciSchuzkaDite(int p_vID)
        {
            return vdm.VedouciSchuzkaDite(p_vID);
        }

        public List<Vedouci> GetAll()
        {
            return vdm.SelectAll();
        }
    }
}
