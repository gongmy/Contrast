using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;

namespace CustomTab1.Controllers
{
    public class OrganizationController : Controller
    {
        //
        // GET: /Organization/

        /// <summary>
        /// 组织机构列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Menu = 3;
            ViewBag.Title = "组织机构列表";

            OrganizationModel omodel = new OrganizationModel();
            var organization = omodel.List().ToList();

            return View(organization);
        }

        public ActionResult OrgContrast()
        {
            ViewBag.Menu = 3;
            ViewBag.Title = "与组织匹配的用户信息";
            return View();
        }

    }
}
