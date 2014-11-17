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

            //根据当前账号获取可操作的权限
            bool isOk2 = false;
            if (workflowMain.Contrast_Workflow != null)
            {
                isOk2=workflowMain.Contrast_Workflow.Contrast_AccountID == LoginAccount.Contrast_Account.ID;
            }

            if (!(isOk || isOk2))
            {
                throw new ApplicationException("未找到数据。");
            }
            //获取全部过程
            Contrast_WorkflowDetailModel detailModel = new Contrast_WorkflowDetailModel();
            var list = detailModel.GetAll(id);
            ViewBag.List = list;
            isOk2 = isOk2 && (workflowMain.State == 0);
            ViewBag.ShowOperation = isOk2;
            return View(workflowMain);
        }

        [HttpPost]
        public ActionResult Detail(Contrast_WorkflowMain wm, int hidStatus, string comment)
        {
            Contrast_WorkflowMainModel model = new Contrast_WorkflowMainModel();
            var result = model.Check(wm, LoginAccount.Contrast_Account.ID, hidStatus, comment);
            if (result.HasError)
            {
                return JavaScript("JMessage('" + result.Error.Replace('\'', '"') + "',true)");
            }
            return JavaScript("window.location.href='" + Url.Action("Detail", "Contrast_WorkflowMain", new { id = wm.ID }) + "'");
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
            var list = C_MainModel.GetList_BYAccountID(LoginAccount.Contrast_Account.ID);
            return View(list);
        }

        /// <summary>
        /// 待办事项
        /// </summary>
        /// <returns></returns>
        public ActionResult AgencyMatter()
        {
            ViewBag.Menu = 6;
            ViewBag.Title = "待办事项";

            Contrast_WorkflowMainModel C_MainModel = new Contrast_WorkflowMainModel();
            var list = C_MainModel.GetAgencyList_BYAccountID(LoginAccount.ID);
            return View(list);
        }

        /// <summary>
        /// 已办事项
        /// </summary>
        /// <returns></returns>
        public ActionResult HaveToDoMatter()
        {
            ViewBag.Menu = 6;
            ViewBag.Title = "已办事项";
            Contrast_WorkflowDetailModel detailModel = new Contrast_WorkflowDetailModel();
            var list = detailModel.GetHavetodoMain(LoginAccount.ID);
            return View(list);
        }

        /// <summary>
        /// 审批管理
        /// </summary>
        /// <returns></returns>
        public ActionResult ApprovalManager()
        {

            ViewBag.Menu = 6;
            ViewBag.Title = "审批管理";
            return View();
        }
    }
}
