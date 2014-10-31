using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    /// <summary>
    /// 工作流步骤表
    /// </summary>
    public class Contrast_Workflow : BaseEntity
    {
        public int ID { get; set; }

        /// <summary>
        /// 工作流标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 本步骤审核人
        /// </summary>
        public int? Contrast_AccountID { get; set; }

        public virtual Contrast_Account Contrast_Account { get; set; }

        public bool IsSelfCheck { get; set; }

        public virtual ICollection<Contrast_WorkflowDetail> Contrast_WorkflowDetails { get; set; }

        public virtual ICollection<Contrast_WorkflowMain> Contrast_WorkflowMains { get; set; }
    }
}
