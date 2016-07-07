using System.Security.Principal;
using System.Web.Mvc;
using AspMvc.Infrastructure.PrincipalBinding;
using CRM.Web.ModelBinders;
using CRM.Web.Models;

namespace CRM.Web
{
    public class BinderConfig
    {
        public static void Configure(ModelBinderDictionary binders)
        {
            binders.Add(typeof (IPrincipal), new PrincipalModelBinder());
            binders.Add(typeof(TaxId), new TaxIdModelBinder());
        }
    }
}