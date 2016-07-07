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
        private readonly IClientCommandRepository _repo;

        public ClientListController(IClientCommandRepository repo)
        {
            _repo = repo;
        }

        // GET: ClientList
        public ActionResult Index()
        {
            return View(_repo.GetAll());
        }
    }
}