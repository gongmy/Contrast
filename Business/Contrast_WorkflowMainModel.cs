using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Business
{
    public class Contrast_WorkflowMainModel : BaseModel<Contrast_WorkflowMain>
    {
        /// <summary>
        /// 查询我的申请
        /// </summary>
        /// <param name="AID">用户ID</param>
        /// <returns></returns>
        public List<Contrast_WorkflowMain> GetList_BYAccountID(int AID)
        {
            var list = List().Where(a => a.Contrast_AccountID == AID).OrderByDescending(a => a.CreateTime).ToList();
            return list;
        }

        /// <summary>
        /// 查询代办事项
        /// </summary>
        /// <param name="AID">用户ID</param>
        /// <returns></returns>
        public List<Contrast_WorkflowMain> GetAgencyList_BYAccountID(int AID)
        {
            var list = List().Where(a => a.Contrast_Workflow.Contrast_AccountID == AID).OrderByDescending(a => a.CreateTime).ToList();
            return list;
        }



        public Result Add(Contrast_WorkflowMain contrast_WorkflowMain, string comment)
        {
            Contrast_WorkflowModel WorkflowModel = new Contrast_WorkflowModel();
            var workflowList = WorkflowModel.List().OrderBy(a => a.Sort).ToList();

            var dateTime = DateTime.Now;
            contrast_WorkflowMain.CreateTime = dateTime;
            contrast_WorkflowMain.State = 0;
            contrast_WorkflowMain.Contrast_WorkflowID = workflowList[1].ID;

            Contrast_WorkflowDetail detail = new Contrast_WorkflowDetail();
            detail.Contrast_WorkflowID = workflowList[0].ID;
            detail.Contrast_AccountID = contrast_WorkflowMain.Contrast_AccountID;
            detail.CheckTime = dateTime;
            detail.Status = 1;
            detail.Comment = comment;
            List<Contrast_WorkflowDetail> list = new List<Contrast_WorkflowDetail>();
            list.Add(detail);
            contrast_WorkflowMain.Contrast_WorkflowDetails = list;

            var result = base.Add(contrast_WorkflowMain);
            return result;
        }

        /// <summary>
        /// 审批
        /// </summary>
        public Result Check(Contrast_WorkflowMain contrast_WorkflowMain, int aid, int status, string comment)
        {
            var raw = Get(contrast_WorkflowMain.ID);
            var detail = raw.Contrast_WorkflowDetails.OrderByDescending(a => a.ID).FirstOrDefault();

            Contrast_WorkflowModel WorkflowModel = new Contrast_WorkflowModel();
            int sort = detail.Contrast_Workflow.Sort + 1;
            var workflow = WorkflowModel.List().Where(a => a.Sort == sort).FirstOrDefault();

            Contrast_WorkflowDetail newDetail = new Contrast_WorkflowDetail();
            newDetail.Contrast_WorkflowMainID = contrast_WorkflowMain.ID;
            newDetail.Contrast_WorkflowID = workflow.ID;
            newDetail.Contrast_AccountID = aid;
            newDetail.CheckTime = DateTime.Now;
            newDetail.Status = status;
            newDetail.Comment = comment;
            Contrast_WorkflowDetailModel detailModel = new Contrast_WorkflowDetailModel();
            var result = detailModel.Add(newDetail);
            if (result.HasError == false)
            {
                //获取下一节点
                var nextWorkflow = WorkflowModel.List().Where(a => a.Sort == (workflow.Sort + 1)).FirstOrDefault();
                if (nextWorkflow != null)
                {
                    if (status == 0)
                    {
                        contrast_WorkflowMain.Contrast_WorkflowID = null;
                        contrast_WorkflowMain.State =2;
                    }
                    else
                    {
                        contrast_WorkflowMain.Contrast_WorkflowID = nextWorkflow.ID;
                        contrast_WorkflowMain.State = 0;
                    }
                }
                else
                {
                    contrast_WorkflowMain.Contrast_WorkflowID = null;
                    if (status == 1)
                    {
                        contrast_WorkflowMain.State = 2;
                    }
                    else
                    {
                        contrast_WorkflowMain.State = 2;
                    }
                }
                contrast_WorkflowMain.Contrast_AccountID = raw.Contrast_AccountID;
                contrast_WorkflowMain.CreateTime = raw.CreateTime;
                contrast_WorkflowMain.Contrast_OrganizationID = raw.Contrast_OrganizationID;
                contrast_WorkflowMain.Contrast_UserInfoID = raw.Contrast_UserInfoID;
                result = Edit(contrast_WorkflowMain);
            }
            return result;
        }
    }
}
