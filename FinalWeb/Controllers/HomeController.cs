using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult ItemCheck() //must be name after .cshtml in Home folder
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DGood() //must be name after .cshtml in Home folder
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Sta() //must be name after .cshtml in Home folder
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}