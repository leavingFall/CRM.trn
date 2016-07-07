using CRM.Web.Models;
using System.Collections.Generic;

namespace CRM.Web.DAL
{
    public interface IClientCommandRepository
    {
        Client Get(int id);

        IEnumerable<ClientSummary> GetAll();

        void Update(Client client);

        void Add(Client client);

        bool ClientExist(TaxId taxId);
    }
}