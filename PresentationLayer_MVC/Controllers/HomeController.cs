using PresentationLayer_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VIS_Desktop.DataAccessLayer.DataMappers;

namespace PresentationLayer_MVC.Controllers
{
    public class HomeController : Controller
    {
        AkceDataMapper adm = new AkceDataMapper();
        VedouciDataMapper vdm = new VedouciDataMapper();
        SchuzkyDataMapper sdm = new SchuzkyDataMapper();

        public ActionResult Index()
        {
            var Akce = adm.SelectUpcoming();
            var Vedouci = vdm.SelectAll();
            var Schuzky = sdm.SelectAll();

            return View("Index", new IndexViewModel { Events = Akce, Leaders = Vedouci, Scheduled = Schuzky});
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}