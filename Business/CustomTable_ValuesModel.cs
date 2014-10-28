using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using Business.Commons;
using System.Data;

namespace Business
{
    public class CustomTable_ValuesModel : BaseModel<CustomTable_Values>
    {
        /// <summary>
        /// 添加内容数据
        /// </summary>
        /// <param name="CMID"></param>
        /// <param name="Options"></param>
        /// <returns></returns>
        public Result AddCustomValInfo(int CMID, string Options)
        {

            CustomTable_ColumnModel CT_Cmodel = new CustomTable_ColumnModel();
            Result result = new Result();
            Common com = new Common();
            //新增的数据
            DataTable addDT = com.JsonToTable(Options);
            //获取自定义表字段
            var columnList = CT_Cmodel.GetList_ByCMID(CMID);
            //标识 唯一字段
            string Identification = DateTime.Now.ToString("yyyyMMddHHmmsss") + com.CreateRandom("", 6);
            //拼接sql
            StringBuilder insertSql = new StringBuilder("INSERT INTO dbo.CustomTable_Values( CustomTable_MainID ,CustomTable_ColumnID,RowValues ,Identification,SaveDate) ");

            for (int i = 0; i < addDT.Rows.Count; i++)
            {
                insertSql.AppendFormat(" SELECT {0},{1},'{2}','{3}','{4}' UNION ALL", CMID, columnList[i].ID, addDT.Rows[i][0], Identification, DateTime.Now.ToString());
            }
            var OptionSql = insertSql.ToString();
            OptionSql = OptionSql.Remove(OptionSql.Length - " UNION ALL".Length);

            base.SqlExecute(OptionSql);

            return result;
        }

        /// <summary>
        /// 修改内容数据
        /// </summary>
        /// <param name="CMID"></param>
        /// <param name="Options"></param>
        /// <returns></returns>
        public Result EditCustomValInfo(int CMID, string Options, string Identification)
        {
            CustomTable_ColumnModel CT_Cmodel = new CustomTable_ColumnModel();
            Result result = new Result();
            Common com = new Common();
            //修改的数据
            DataTable updDT = com.JsonToTable(Options);
            //获取自定义表字段
            var columnList = CT_Cmodel.GetList_ByCMID(CMID);
            //拼接sql
            StringBuilder updateSql = new StringBuilder();
            for (int i = 0; i < updDT.Rows.Count; i++)
            {
                updateSql.AppendFormat(" update CustomTable_Values set RowValues='{0}' where  CustomTable_ColumnID={1} and Identification='{2}' ", updDT.Rows[i][0], columnList[i].ID, Identification);
            }
            base.SqlExecute(updateSql.ToString());
            return result;
        }


        /// <summary>
        /// 根据标识生成数据
        /// </summary>
        /// <param name="CMID"></param>
        /// <param name="Identification"></param>
        /// <returns></returns>
        public Result DelCustomVal_BYIdentification(int CMID, string Identification)
        {
            Result result = new Result();
            string sql = string.Format("Delete CustomTable_Values where CustomTable_MainID={0} and Identification='{1}'", CMID, Identification);
            int cnt = base.SqlExecute(sql);
            return result;
        }


        /// <summary>
        /// 根据CustomTable_Main主表ID删除数据表数据
        /// </summary>
        /// <param name="CMID"></param>
        /// <returns></returns>
        public Result DelCustomVal_BYCMID(int CMID)
        {
            Result result = new Result();
            string sql = string.Format("Delete CustomTable_Values where CustomTable_MainID={0}", CMID);
            int cnt = base.SqlExecute(sql);
            return result;
        }
    }
}
