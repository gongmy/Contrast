using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class CustomTable_Values : BaseEntity
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 自定义表名ID(主表ID)
        /// </summary>
        [Display(Name = "自定义表名ID(主表ID)")]
        public int CustomTable_MainID { get; set; }
        public virtual CustomTable_Main CustomTable_Main { get; set; }


        /// <summary>
        /// 自定义列名ID(主表ID)
        /// </summary>
        [Display(Name = "自定义列名ID(主表ID)")]
        public int CustomTable_ColumnID { get; set; }
        public virtual CustomTable_Column CustomTable_Column { get; set; }

        /// <summary>
        /// 自定义表行数据
        /// </summary>
        [Display(Name = "自定义表行数据")]
        [StringLength(2000, ErrorMessage = "字数不能超过2000字")]
        public string RowValues { get; set; }

        /// <summary>
        /// 标识（用于确定一行数据）
        /// </summary>
        [Display(Name = "标识（用于确定一行数据）")]
        public string Identification { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [Display(Name = "创建日期")]
        public DateTime SaveDate { get; set; }
    }
}
