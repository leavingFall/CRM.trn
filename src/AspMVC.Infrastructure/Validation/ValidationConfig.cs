using System.Web.Mvc;

namespace AspMvc.Infrastructure.Validation
{
  public class ValidationConfig
  {
    public static void Configure(ModelBinderDictionary binders)
    {
      binders.DefaultBinder = new ValidatingModelBinder();
    }
  }
}