﻿using System;
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
    public ActionResult Index(IIdentity identity)
    {
      return View(identity);
    }

        public ActionResult Index2()
        {
            return this.RedirectToAction<HomeController>(p => p.About());
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