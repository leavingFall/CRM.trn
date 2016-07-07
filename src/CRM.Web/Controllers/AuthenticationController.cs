using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        [ChildActionOnly]
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                return PartialView("Authenticated");
            }
            else
            {
                return PartialView("Anonymous");
            }
        }
    }
}