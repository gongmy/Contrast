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
                return JavaScript("JMessage('"+result.Error.Replace('\'','"')+"',true)");
            }
            return JavaScript("window.location.href='" + Url.Action("MyWorkFlow", "Contrast_WorkflowMain") + "'");
        }
    }
}
