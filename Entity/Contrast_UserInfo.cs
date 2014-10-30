using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Contrast_UserInfo : BaseEntity
    {
        public int ID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 婚否
        /// </summary>
        public bool Privacies { get; set; }
        /// <summary>
        /// 法人
        /// </summary>
        public string LegalPerson { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 需求资金（单位 万）
        /// </summary>
        public decimal DemandMoney { get; set; }
        /// <summary>
        /// 需求周期（月）
        /// </summary>
        public int DemandMonth { get; set; }
        /// <summary>
        /// 可承受年利息
        /// </summary>
        public double AcceptInterest { get; set; }

        public virtual ICollection<Contrast_WorkflowMain> Contrast_WorkflowMains { get; set; }
    }

    public class User_Organization
    {
        public Contrast_UserInfo user { get; set; }
        public Contrast_Organization org { get; set; }
    }
}
