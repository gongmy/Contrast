using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomTab1.Controllers
{
    public class Contrast_WorkflowMainController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Menu = 6;
            return View();
        }

    }
}
