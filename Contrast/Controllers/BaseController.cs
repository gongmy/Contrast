using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using System.Web.Routing;

namespace CustomTab1.Controllers
{
    public class BaseController : Controller
    {
        protected SessionLoginUser LoginAccount
        {
            get
            {
                var account = Session["SessionLoginUser"] as SessionLoginUser;
                return account;
            }
            set { Session["SessionLoginUser"] = value; }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var controller = filterContext.RequestContext.RouteData.Values["controller"] as string;
            var action = filterContext.RequestContext.RouteData.Values["action"] as string;
            var area = filterContext.RouteData.DataTokens["area"] as string;

            //上一次请求信息
            string url = "";
            var request = filterContext.RequestContext.HttpContext.Request;
            if (request != null && request.CurrentExecutionFilePath!=null)
            {
                url = request.CurrentExecutionFilePath;
            }
            if (LoginAccount == null)
            {
                filterContext.Result = new RedirectToRouteResult("Default",
                    new RouteValueDictionary{
                        { "controller", "Login" },
                        { "action", "Index" },
                        {"url",url}
                });
                return;
            }
            base.OnActionExecuting(filterContext);
        }

    }
}
