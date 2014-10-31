using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Entity;

namespace CustomTab1.Controllers
{
    public class Contrast_WorkflowMainController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Menu = 6;
            return View();
        }

        public ActionResult Add(int UserInfoID, int OrganizationID)
        {
            Contrast_UserInfoModel userModel = new Contrast_UserInfoModel();
            OrganizationModel organizationModel = new OrganizationModel();
            var user = userModel.Get(UserInfoID);
            var organization = organizationModel.Get(OrganizationID);
            Contrast_WorkflowMain workflowMain = new Contrast_WorkflowMain();
            workflowMain.Contrast_UserInfo = user;
            workflowMain.Contrast_UserInfoID = UserInfoID;
            workflowMain.Contrast_Organization = organization;
            workflowMain.Contrast_OrganizationID = OrganizationID;
            return View(workflowMain);
        }

        [HttpPost]
        public ActionResult Add(Contrast_WorkflowMain contrast_WorkflowMain, string comment)
        {
            Contrast_WorkflowMainModel model = new Contrast_WorkflowMainModel();
            contrast_WorkflowMain.Contrast_AccountID = LoginAccount.Contrast_Account.ID;
            var result = model.Add(contrast_WorkflowMain, comment);
            if (result.HasError)
            {
                return JavaScript("JMessage('" + result.Error.Replace('\'', '"') + "',true)");
            }
            return JavaScript("window.location.href='" + Url.Action("MyWorkFlow", "Contrast_WorkflowMain") + "'");
        }

        public ActionResult Detail(int id)
        {
            Contrast_WorkflowMainModel model = new Contrast_WorkflowMainModel();
            var workflowMain = model.Get(id);
            var isOk = workflowMain.Contrast_WorkflowDetails.Any(a => a.Contrast_AccountID == LoginAccount.Contrast_Account.ID);
            if (!isOk)
            {
                throw new ApplicationException("未找到数据。");
            }
            //获取全部过程
            Contrast_WorkflowDetailModel detailModel=new Contrast_WorkflowDetailModel();
            var list= detailModel.GetAll(id);
            ViewBag.List=list;
            return View(workflowMain);
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
        public string GetApproval(int MainID)
        {
            return "";
        }
    }
}
