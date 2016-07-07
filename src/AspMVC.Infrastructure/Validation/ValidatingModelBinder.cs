using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Results;

namespace AspMvc.Infrastructure.Validation
{
  internal class ValidatingModelBinder : System.Web.Mvc.DefaultModelBinder
  {
    protected override void OnModelUpdated(ControllerContext controllerContext, ModelBindingContext bindingContext)
    {
      base.OnModelUpdated(controllerContext, bindingContext);

      var validator = GetValidatorFor(bindingContext.Model.GetType());

      if (validator != null)
      {
        var result = validator.Validate(bindingContext.Model);

        UpdateModelState(bindingContext, result);
      }
    }

    private static IValidator GetValidatorFor(Type type)
    {
      var validatorAttribute = type.GetCustomAttributes(typeof(ValidatorAttribute), true)
        .OfType<ValidatorAttribute>()
        .FirstOrDefault();

      if (validatorAttribute == null || validatorAttribute.ValidatorType == (Type)null)
      {
        return null;
      }

      var constructor = validatorAttribute.ValidatorType.GetConstructors()
        .Single();

      var parameters = constructor.GetParameters()
        .Select(x => DependencyResolver.Current.GetService(x.ParameterType))
        .ToArray();

      return constructor.Invoke(parameters) as IValidator;
    }

    private static void UpdateModelState(ModelBindingContext bindingContext, ValidationResult result)
    {
      if (!result.IsValid)
      {
        var modelPrefix = (!string.IsNullOrEmpty(bindingContext.ModelName)
         && !bindingContext.ValueProvider.ContainsPrefix(bindingContext.ModelName)
         && bindingContext.FallbackToEmptyPrefix)
          ? string.Empty
          : bindingContext.ModelName;

        foreach (var failure in result.Errors)
        {
          var key = string.IsNullOrEmpty(modelPrefix) ? failure.PropertyName : (string.Format("{0}.{1}", modelPrefix, failure.PropertyName));

          bindingContext.ModelState.AddModelError(key, failure.ErrorMessage);

          if (bindingContext.ModelState.ContainsKey(key) == false)
          {
            bindingContext.ModelState.SetModelValue(key, new ValueProviderResult(failure.AttemptedValue ?? string.Empty, (failure.AttemptedValue ?? string.Empty).ToString(), CultureInfo.CurrentCulture));
          }
        }
      }
    }
  }
}
