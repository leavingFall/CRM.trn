using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspMvc.Infrastructure.HtmlHelpers
{
  public static class UrlBuilder
  {
    public static string BuildFromExpression<TController>(this UrlHelper urlHelper, Expression<Action<TController>> expression) where TController : Controller
    {
      RouteValueDictionary trouteValues = Microsoft.Web.Mvc.Internal.ExpressionHelper.GetRouteValuesFromExpression(expression);

      return urlHelper.Action(trouteValues["action"].ToString(), trouteValues["controller"].ToString(), trouteValues);
    }
  }
}