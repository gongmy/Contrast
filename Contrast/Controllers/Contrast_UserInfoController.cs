using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;

namespace CustomTab1.Controllers
{
    public class Contrast_UserInfoController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Menu = 1;
            Contrast_UserInfoModel model = new Contrast_UserInfoModel();
            var list= model.List().ToList();
            return View(list);
        }


        public ActionResult UserContrast()
        {
            ViewBag.Menu = 2;
            Contrast_UserInfoModel model = new Contrast_UserInfoModel();
            var list = model.UserContrast();
            return View(list);
        }
    }
}
