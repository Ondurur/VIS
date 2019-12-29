using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VIS_Desktop.DTO;

namespace PresentationLayer_MVC.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Akce> Events { get; set; }

        public IEnumerable<Vedouci> Leaders { get; set; }

        public IEnumerable<Schuzky> Scheduled { get; set; }

        public void idk()
        {
            this.Scheduled.ElementAt(5).DatumK.ToString();
        }
    }
}