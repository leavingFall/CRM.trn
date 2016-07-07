using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Web.DAL;
using CRM.Web.Model;

namespace CRM.Web.Controllers
{
    public class AddClientWizardController : Controller
    {
        private readonly IClientCommandRepository _repo;

        public AddClientWizardController(IClientCommandRepository repo)
        {
            _repo = repo;
        }

        // GET: AddClientWizard
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Client c)
        {
            _repo.Add(c);

            return RedirectToAction("Index", "ClientList");
        }
    }
}