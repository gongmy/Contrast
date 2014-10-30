using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;

namespace CustomTab1.Controllers
{
    public class Contrast_WorkflowController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Menu = 5;
            Contrast_WorkflowModel model = new Contrast_WorkflowModel();
            var list= model.GetList();
            return View(list);
        }
    }
}
