using System.Diagnostics;
using System.Web.Mvc;

namespace GlobalFiltersExample.Filters
{
    public class StopwatchFilterAttribute : ActionFilterAttribute
    {
        private Stopwatch _stopwatch;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _stopwatch = new Stopwatch();

            _stopwatch.Start();
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            _stopwatch.Stop();

            var headers = filterContext.HttpContext.Response.Headers;
            headers["X-Stopwatch"] = _stopwatch.ElapsedMilliseconds.ToString();
        }
    }
}