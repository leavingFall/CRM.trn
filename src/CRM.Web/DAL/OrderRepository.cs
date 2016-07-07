using System.Collections.Generic;

namespace CRM.Web.DAL
{
  public class OrderRepository
  {
    private static Dictionary<int, int> _orders = new Dictionary<int, int>();

    static OrderRepository()
    {
      _orders.Add(1, 12);
      _orders.Add(2, 1);
      _orders.Add(3, 123);
    }

    public IEnumerable<int> GetOrderCountForClient(OrderQuery query)
    {
      List<int> result = new List<int>();
      foreach (int clientId in query.ClientIds)
      {
        result[clientId] = _orders[clientId];
      }
      return result;
    }
  }
}