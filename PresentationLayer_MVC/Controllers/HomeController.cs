using BussinessLayer.Services;
using PresentationLayer_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer_MVC.Controllers
{
    public class HomeController : Controller
    {
        AkceServices ac = new AkceServices();
        VedouciServices vc = new VedouciServices();
        SchuzkyServices sc = new SchuzkyServices();

        public ActionResult Index()
        {
            var Akce = ac.all;
            var Vedouci = vc.GetAll();
            var Schuzky = sc.GetAll();

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