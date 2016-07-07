using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspMvc.Infrastructure.MultiTab
{
  public static class ControllerExtensionMethods
  {
    public static string GetGuid(this Controller controller)
    {
      return controller.RouteData.Values["guid"].ToString();
    }

    public static Route MapGuidRoute(this RouteCollection routes, string name, string url, object defaults, string[] namespaces)
    {
      if (routes == null)
        throw new ArgumentNullException("routes");
      if (url == null)
        throw new ArgumentNullException("url");
      GuidRoute route = new GuidRoute(url, defaults)
      {
        DataTokens = new RouteValueDictionary()
      };
      if (namespaces != null && namespaces.Length > 0)
        route.DataTokens["Namespaces"] = (object)namespaces;
      routes.Add(name, (RouteBase)route);
      return route;
    }
  }
}