using System.Collections.Generic;
using CRM.Web.Models;

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