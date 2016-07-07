using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace AspMvc.Infrastructure.Validation
{
  public static class ModelStateExtensions
  {
    public static void AddModelError<TModel>(this ModelStateDictionary dictionary, Expression<Func<TModel, object>> expression, string errorMessage)
    {
      dictionary.AddModelError(ExpressionHelper.GetExpressionText(expression), errorMessage);
    }
  }
}