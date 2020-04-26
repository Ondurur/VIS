using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS_Desktop.DTO
{
    public class AkceDeti
    {
        public AkceDeti(int akce_aid, int deti_did)
        {
            this.Akce_aid = akce_aid;
            this.Deti_did = deti_did;
        }

        public int Akce_aid { get; set; }
        public int Deti_did { get; set; }
    }
}
