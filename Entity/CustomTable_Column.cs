using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class CustomTable_Column : BaseEntity
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
        /// 自定义列名
        /// </summary>
        [Display(Name = "自定义列名")]
        [Required(ErrorMessage = "请输入列名")]
        [StringLength(50, ErrorMessage = "列名不能超过50字")]
        public string ColumnName { get; set; }

        /// <summary>
        /// 列类型（枚举）
        /// </summary>
        [Display(Name = "列类型（枚举）")]
        public int Enum_CustomTable_ColumnType { get; set; }


        //----------------------子表------------------------------------------
        /// <summary>
        /// 自定义表数据存储表
        /// </summary>
        public virtual ICollection<CustomTable_Values> CustomTable_Values { get; set; }
    }
}
