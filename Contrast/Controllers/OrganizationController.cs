using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Entity;

namespace CustomTab1.Controllers
{
    public class OrganizationController : BaseController
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
            ViewBag.Menu = 4;
            ViewBag.Title = "与组织匹配的用户信息";

            OrganizationModel omodel = new OrganizationModel();
            var Date = omodel.GetContrastInfo();

            return View(Date);
        }


        public ActionResult Add()
        {
            ViewBag.Menu = 3;
            ViewBag.Title = "添加组织机构";
            return View();
        }

        [HttpPost]
        public ActionResult Add(Contrast_Organization Corg)
        {

            OrganizationModel omodel = new OrganizationModel();
            omodel.Add(Corg);
            return JavaScript("window.location.href='" + Url.Action("Index", "Organization") + "'");
        }
    }
}
