using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class CustomTable_Main : BaseEntity
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 自定义表名
        /// </summary>
        [Display(Name = "自定义表名")]
        [Required(ErrorMessage = "请输入表名")]
        public string TableMain { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [Display(Name = "创建日期")]
        public DateTime SaveDate { get; set; }

        //----------------------子表------------------------------------------
        /// <summary>
        /// 自定义列标题表
        /// </summary>
        public virtual ICollection<CustomTable_Column> CustomTable_Column { get; set; }
        /// <summary>
        /// 自定义表数据存储表
        /// </summary>
        public virtual ICollection<CustomTable_Values> CustomTable_Values { get; set; }

    }
}
