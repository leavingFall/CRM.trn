using System;
using System.Web.Mvc;
using CRM.Web.Models;

namespace CRM.Web.ModelBinders
{
    public class TaxIdModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (!TaxId.IsValid(value.AttemptedValue))
            {
                var ms = (controllerContext.Controller as Controller).ModelState;
                ms.AddModelError(bindingContext.ModelName, "Invalid TaxId");
                //...ms.SetModelValue(null, null);
                //return null;
            }
            return new TaxId(value.AttemptedValue);
        }
    }
}