using CRM.Web.Models;

namespace CRM.Web.DAL
{
  public class Client
  {
    public int Id { get; set; }

    public string Name { get; set; }
    public TaxId TaxId { get; set; }
    public string Email { get; set; }

    public Address Address { get; set; }
  }
}