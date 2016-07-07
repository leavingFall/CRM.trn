namespace CRM.Web.Models
{
  public class Currency
  {
    public Currency(string currencyCode)
    {
      CurrencyCode = currencyCode;
    }

    public string CurrencyCode { get; private set; }

  }
}