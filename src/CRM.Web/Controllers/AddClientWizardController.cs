using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Web.DAL;
using CRM.Web.Models;
using Microsoft.Web.Mvc;
using Microsoft.Web.Mvc.Html;

namespace CRM.Web.Controllers
{
    public class AddClientWizardController : Controller
    {
        private IClientCommandRepository Repository { get; set; }

        public AddClientWizardController(IClientCommandRepository r)
        {
            this.Repository = r;
        }

        public ActionResult Index()
        {
            return View(new Client() { Name = null, TaxId = new TaxId() });
        }


        [HttpPost]
        public ActionResult Index(Client c)
        {
            if (ModelState.IsValid)
            {
                if (!this.Repository.ClientExist(c.TaxId))
                {
                    this.Repository.Add(c);
                }
            }
            return this.RedirectToAction<ClientListController>(x => x.Index());
        }

        //public ActionResult Create([Bind(Prefix = "abc_")]AddClientModel m)
        //{

        //}
    }
}