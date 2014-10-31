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
    }

    public class Contrast_WorkflowMainDetail
    {
        public int? ID { get; set; }

        public int wid { get; set; }

        public string Title { get; set; }

        public int? Contrast_AccountID { get; set; }

        public bool IsSelfCheck { get; set; }

        public DateTime? CheckTime { get; set; }

        public string Comment { get; set; }

        public int? Status { get; set; }
    }
}
