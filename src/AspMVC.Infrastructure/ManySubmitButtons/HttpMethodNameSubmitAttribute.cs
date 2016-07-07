using System;
using System.Reflection;
using System.Web.Mvc;

namespace AspMvc.Infrastructure.ManySubmitButtons
{
  /// <summary>
  /// http://blog.ashmind.com/2010/03/15/multiple-submit-buttons-with-asp-net-mvc-final-solution/?ith-asp-net-mvc-final-solution/
  /// </summary>
  public class HttpMethodNameSubmitAttribute : ActionNameSelectorAttribute
  {
    public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
    {
      foreach (var item in controllerContext.HttpContext.Request.Form.Keys)
      {
        if (item.ToString().StartsWith("action"))
        {
          string action = item.ToString().Replace("action_", "");
          return action == methodInfo.Name;
        }
      }
      return false;
    }
  }
}
