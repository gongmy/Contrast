using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Contrast_WorkflowMain:BaseEntity
    {
        public int ID { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int Contrast_AccountID { get; set; }

        public virtual Contrast_Account Contrast_Account { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 状态 0：进行中   1：完成   2：关闭
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 组织
        /// </summary>
        public int Contrast_OrganizationID { get; set; }

        public virtual Contrast_Organization Contrast_Organization { get; set; }

        public int Contrast_UserInfoID { get; set; }

        public virtual Contrast_UserInfo Contrast_UserInfo { get; set; }

        public virtual ICollection<Contrast_WorkflowDetail> Contrast_WorkflowDetails { get; set; }

        /// <summary>
        /// 当前节点
        /// </summary>
        public int? Contrast_WorkflowID { get; set; }

        public virtual Contrast_Workflow Contrast_Workflow { get; set; }
    }

    public class Contrast_WorkflowMainDetail
    {
        public int? ID { get; set; }

        public int wid { get; set; }

        public string Title { get; set; }

        /// <summary>
        /// 分配审批人ID
        /// </summary>
        public int? Contrast_AccountID1 { get; set; }

        /// <summary>
        /// 审批人名称
        /// </summary>
        public string Contrast_AccountName1 { get; set; }

        /// <summary>
        /// 真实操作的审批人ID
        /// </summary>
        public int? Contrast_AccountID2 { get; set; }

        /// <summary>
        /// 真实操作的审批人名称
        /// </summary>
        public string Contrast_AccountName2 { get; set; }

        public bool IsSelfCheck { get; set; }

        public DateTime? CheckTime { get; set; }

        public string Comment { get; set; }

        public int? Status { get; set; }
    }
}
