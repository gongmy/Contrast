﻿using System;
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
            var list = List().Where(a => a.Contrast_AccountID == AID).OrderByDescending(a=>a.CreateTime).ToList();
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
            var dateTime = DateTime.Now;
            contrast_WorkflowMain.CreateTime = dateTime;
            contrast_WorkflowMain.State = 0;

            Contrast_WorkflowModel WorkflowModel = new Contrast_WorkflowModel();
            var workflowList = WorkflowModel.List().OrderBy(a => a.Sort).ToList();
            Contrast_WorkflowDetail detail = new Contrast_WorkflowDetail();
            detail.Contrast_WorkflowID = workflowList[0].ID;
            detail.Contrast_AccountID = contrast_WorkflowMain.Contrast_AccountID;
            detail.CheckTime = dateTime;
            detail.Status = 1;
            detail.Comment = comment;
            detail.Contrast_WorkflowID = workflowList[1].ID;
            List<Contrast_WorkflowDetail> list = new List<Contrast_WorkflowDetail>();
            list.Add(detail);
            contrast_WorkflowMain.Contrast_WorkflowDetails = list;

            var result = base.Add(contrast_WorkflowMain);
            return result;
        }

    }
}
