using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Business
{
    public class CustomTable_ColumnModel : BaseModel<CustomTable_Column>
    {
        /// <summary>
        /// 根据CMID 获取字段信息
        /// </summary>
        /// <param name="CMID"></param>
        /// <returns></returns>
        public List<CustomTable_Column> GetList_ByCMID(int CMID)
        {
            var list = base.List().Where(a => a.CustomTable_MainID == CMID).OrderBy(a=>a.ID).ToList();
            return list;
        }

        /// <summary>
        /// 根据CustomTable_Main主表ID删除字段表数据
        /// </summary>
        /// <param name="CMID"></param>
        /// <returns></returns>
        public Result DelCustomColumn_BYCMID(int CMID)
        {
            Result result = new Result();
            string sql = string.Format("Delete CustomTable_Column where CustomTable_MainID={0}", CMID);
            int cnt = base.SqlExecute(sql);
            return result;
        }
    }
}
