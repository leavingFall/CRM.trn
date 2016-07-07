using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspMvc.Infrastructure.GrzesiekTimerAttribute
{
    public class GrzesiekTimerAttribute : ActionFilterAttribute
    {
        private DateTime _start;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _start = DateTime.Now;

            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Trace.WriteLine("czas trwania requestu: " + DateTime.Now.Subtract(_start).TotalMilliseconds.ToString());

            base.OnActionExecuted(filterContext);
        }
    }
}
