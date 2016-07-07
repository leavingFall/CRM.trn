using System.Web;

namespace AspMvc.Infrastructure.DisplayModes
{
  public static class DisplayModesHelper
  {
    public static bool IsAnndroidDevice(HttpContextBase context)
    {
      return context.Request.UserAgent.Contains("Android");
    }

    public static bool IsInternetExplorer(HttpContextBase context)
    {
      return context.Request.Browser.IsBrowser("InternetExplorer");
    }
  }
}