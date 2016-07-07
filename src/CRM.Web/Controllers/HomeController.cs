using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Microsoft.Web.Mvc;

namespace CRM.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(IPrincipal p)
        {
            return View(p);
        }

        //public ActionResult Index()
        //{
        //    return this.RedirectToAction<HomeController>(f => f.Index(null));
        //}

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