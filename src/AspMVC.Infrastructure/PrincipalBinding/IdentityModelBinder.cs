using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspMvc.Infrastructure.PrincipalBinding
{
    public class IdentityModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return controllerContext.HttpContext.User.Identity;
        }
    }
}
