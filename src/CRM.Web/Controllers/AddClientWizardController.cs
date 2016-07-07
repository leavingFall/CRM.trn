using CRM.Application.Handlers;
using CRM.Web.DAL;
using Microsoft.Web.Mvc;
using System.Web.Mvc;

namespace CRM.Web.Controllers
{
    public class AddClientWizardController : Controller
    {
        private readonly ICommandHandler<Client> _handler;

        public AddClientWizardController(ICommandHandler<Client> handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Client client)
        {
            if (ModelState.IsValid)
            {
                _handler.Handle(client);
            }

            return this.RedirectToAction<ClientListController>(x => x.Index());
        }

        [HttpPost]
        public ActionResult Back()
        {
            return this.RedirectToAction<HomeController>(x => x.About());
        }

        [HttpPost]
        public ActionResult Cancel()
        {
            return this.RedirectToAction<ClientListController>(x => x.Index());
        }
    }

    public class AddClientHandler : ICommandHandler<Client>
    {
        private IClientCommandRepository _repository;

        public AddClientHandler(IClientCommandRepository repository)
        {
            _repository = repository;
        }

        public void Handle(Client client)
        {
            if (!_repository.ClientExist(client.TaxId))
            {
                _repository.Add(client);
            }
        }
    }
}