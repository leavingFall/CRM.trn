using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace CRM.Web
{
    public class LogTimeAttribute : ActionFilterAttribute
    {
        private DateTime StartedTime { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.StartedTime = DateTime.Now;
            Trace.Write(DateTime.Now.ToString() + ": Executing action " + filterContext.ActionDescriptor.ActionName);
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            Trace.Write(DateTime.Now.ToString() + ": Executed action " + filterContext.ActionDescriptor.ActionName + ", duration " + DateTime.Now.Subtract(this.StartedTime));
        }
    }
}