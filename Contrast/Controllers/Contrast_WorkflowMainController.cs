using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;

namespace CustomTab1.Controllers
{
    public class Contrast_WorkflowMainController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Menu = 6;
            return View();
        }

        /// <summary>
        /// 我的申请
        /// </summary>
        /// <returns></returns>
        public ActionResult MyWorkFlow()
        {
            ViewBag.Menu = 6;
            ViewBag.Title = "我的申请";

            Contrast_WorkflowMainModel C_MainModel = new Contrast_WorkflowMainModel();
            var list = C_MainModel.GetList_BYAccountID(LoginAccount.ID);
            return View(list);
        }

        /// <summary>
        /// 代办事项
        /// </summary>
        /// <returns></returns>
        public ActionResult AgencyMatter()
        {
            ViewBag.Menu = 6;
            ViewBag.Title = "代办事项";
            return View();
        }

        /// <summary>
        /// 已办事项
        /// </summary>
        /// <returns></returns>
        public ActionResult HaveToDoMatter()
        {
            ViewBag.Menu = 6;
            ViewBag.Title = "已办事项";
            return View();
        }

        /// <summary>
        /// 获取当前处理人
        /// </summary>
        /// <returns></returns>
        public string  GetApproval(int MainID)
        {

            return "";
        }
    }
}
