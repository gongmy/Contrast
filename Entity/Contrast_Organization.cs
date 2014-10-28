using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Contrast_Organization : BaseEntity
    {
        public int ID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 资质
        /// </summary>
        public string Qualifications { get; set; }
        /// <summary>
        /// 所在地
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 信用评级
        /// </summary>
        public string Credit { get; set; }
        /// <summary>
        /// 法人
        /// </summary>
        public string LegalPerson { get; set; }
        /// <summary>
        /// 担保
        /// </summary>
        public string Guarantee { get; set; }
        /// <summary>
        /// 提供资金（单位 万）
        /// </summary>
        public decimal ProvideMoney { get; set; }

        /// <summary>
        /// 时间范围开始周期（月）
        /// </summary>
        public int BeginMonth { get; set; }

        /// <summary>
        /// 时间范围结束周期（月）
        /// </summary>
        public int EndMonth { get; set; }

        /// <summary>
        /// 需求年利息
        /// </summary>
        public double DemandInterest { get; set; }


    }
}
