using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Web.DAL;

namespace CRM.Web.Controllers
{
    public class ClientListController : Controller
    {
        private IClientCommandRepository Repository { get; set; }


        public ClientListController(IClientCommandRepository r)
        {
            this.Repository = r;
        }

        // GET: ClientList
        public ActionResult Index()
        {
            var r = this.Repository.GetAll();
            return View(r);
        }
    }
}