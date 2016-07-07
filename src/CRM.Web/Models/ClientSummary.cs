namespace CRM.Web.Models
{
  public class ClientSummary
  {
    public int Id { get; set; }

    public string Name { get; set; }
    public string TaxId { get; set; }
    public int OrdersCount { get; set; }
  }
}