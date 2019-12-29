using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIS_Desktop.DataAccessLayer.DataMappers;
using VIS_Desktop.DTO;

namespace BussinessLayer.Services
{
    public class SchuzkyServices
    {
        SchuzkyDataMapper sdm;

        public SchuzkyServices()
        {
            sdm = new SchuzkyDataMapper();
        }

        public List<Schuzky> GetAll()
        {
            return sdm.SelectAll();
        }
    }
}
