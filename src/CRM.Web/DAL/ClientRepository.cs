using CRM.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace CRM.Web.DAL
{
  public class ClientRepository : IClientCommandRepository
  {
    private static Dictionary<int, Client> _clients = new Dictionary<int, Client>();

    static ClientRepository()
    {
      _clients.Add(1, new Client() { Id = 1, Name = "Microsoft", TaxId = new TaxId("12345678901"), Address = new Address("Kowalskiego 30/15", "Redmont", null, null) });
      _clients.Add(2, new Client() { Id = 2, Name = "Google", TaxId = new TaxId("12345678903"), Address = new Address("Kowalskiego 30/15", "Redmont", null, null) });
      _clients.Add(3, new Client() { Id = 3, Name = "Apple", TaxId = new TaxId("12345678902"), Address = new Address("Kowalskiego 30/15", "Redmont", null, null) });
    }

    public Client Get(int id)
    {
      if (_clients.ContainsKey(id))
      {
        return _clients[id];
      }
      return null;
    }

    public void Update(Client client)
    {
      _clients[client.Id] = client;
    }

    public void Add(Client client)
    {
      client.Id = _clients.Count + 1;
      _clients.Add(client.Id, client);
    }

    public bool ClientExist(TaxId taxId)
    {
      return _clients.Any(f => f.Value.TaxId == taxId);
    }

    public IEnumerable<ClientSummary> GetAll()
    {
      return _clients.Values.Select(f => new ClientSummary() { Id = f.Id, Name = f.Name, TaxId = f.TaxId.ToString() });
    }

    public IEnumerable<ClientType> GetClientTypes()
    {
      return new[]
      {
        new ClientType(1, "Jednoosobowy przedsiębiorca"),
        new ClientType(2, "Sp. z o.o."),
        new ClientType(3, "S.A.")
      };
    }

    public bool Exists(TaxId taxId)
    {
      return _clients.Values.Any(f => f.TaxId == taxId);
    }
  }
}