using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    /// <summary>
    /// 工作流详细表
    /// </summary>
    public class Contrast_WorkflowDetail:BaseEntity
    {
        public int ID { get; set; }

        /// <summary>
        /// 工作流
        /// </summary>
        public int Contrast_WorkflowMainID { get; set; }

        public virtual Contrast_WorkflowMain Contrast_WorkflowMain { get; set; }

        /// <summary>
        /// 步骤
        /// </summary>
        public int Contrast_WorkflowID { get; set; }

        public virtual Contrast_Workflow Contrast_Workflow { get; set; }

        /// <summary>
        /// 审批人
        /// </summary>
        public int? Contrast_AccountID { get; set; }

        public virtual Contrast_Account Contrast_Account { get; set; }

        /// <summary>
        /// 审批时间
        /// </summary>
        public DateTime? CheckTime { get; set; }

        /// <summary>
        /// 1：通过    0：未通过
        /// </summary>
        public int Status { get; set; }

        public string Comment { get; set; }

    }
}
