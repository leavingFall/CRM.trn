using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using AspMvc.Infrastructure.PrincipalBinding;
using CRM.Web.Controllers;

namespace CRM.Web.App_Start
{
    public class ModelBindersConfig
    {
        public static void Configure()
        {
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(IIdentity), new IdentityModelBinder());
        }
    }
}