using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data;

namespace Business
{
    public class CustomTable_MainModel : BaseModel<CustomTable_Main>
    {
        /// <summary>
        /// 获取自定义表数据
        /// </summary>
        /// <param name="CMID"></param>
        /// <returns></returns>
        public DataTable GetCustomTableInfo(int CMID)
        {
            DataTable dt = new DataTable();

            string sql = string.Format(@"declare @sql varchar(8000)
                           select @sql = isnull(@sql + '],[' , '') + ColumnName from dbo.CustomTable_Column where CustomTable_MainID = {0} group by ColumnName,ID order by ID 
                           set @sql = '[' + @sql + ']'
                           exec ('select * from (select a.ColumnName,b.RowValues,b.Identification from dbo.CustomTable_Column a,dbo.CustomTable_Values b where a.id= b.CustomTable_ColumnID and  a.CustomTable_MainID = {0}) a pivot (max(RowValues) for ColumnName in (' + @sql + '))b')", CMID);
            return SqlHelper.ExecuteDataset(sql).Tables[0];
        }

        /// <summary>
        /// 添加自定义表与列
        /// </summary>
        /// <param name="ct_m">主表</param>
        /// <param name="Options">列数据（JSON）</param>
        /// <returns></returns>
        public Result AddMain_Column(CustomTable_Main ct_m, string Options)
        {
            Result result = new Result();
            using (System.Transactions.TransactionScope trans = new System.Transactions.TransactionScope())
            {
                //添加主表
                ct_m.SaveDate = DateTime.Now;
                result = base.Add(ct_m);
                if (result.HasError)
                {
                    return result;
                }
                //json转换为List
                var Json = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ColumnOption>>(Options);
                //拼接sql
                StringBuilder insertSql = new StringBuilder("INSERT INTO dbo.CustomTable_Column( CustomTable_MainID ,ColumnName ,Enum_CustomTable_ColumnType) ");
                foreach (var item in Json)
                {
                    insertSql.AppendFormat(" SELECT {0},'{1}','{2}' UNION ALL", ct_m.ID, item.Option, item.TypeVal);
                }
                var OptionSql = insertSql.ToString();
                OptionSql = OptionSql.Remove(OptionSql.Length - " UNION ALL".Length);

                base.SqlExecute(OptionSql);

                trans.Complete();
            }
            return result;
        }

        /// <summary>
        /// 修改自定义表与列
        /// </summary>
        /// <param name="ct_m">主表</param>
        /// <param name="Options">列数据（JSON）</param>
        /// <returns></returns>
        public Result EditMain_Column(CustomTable_Main ct_m, string Options)
        {
            Result result = new Result();
            using (System.Transactions.TransactionScope trans = new System.Transactions.TransactionScope())
            {
                //修改主表
                result = base.Edit(ct_m);
                if (result.HasError)
                {
                    return result;
                }
                //json转换为List
                var Json = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ColumnOption>>(Options);
                //修改后还保留的ID
                StringBuilder jsonIDs = new StringBuilder();
                //新增的字段sql
                StringBuilder insertSql = new StringBuilder(" INSERT INTO dbo.CustomTable_Column( CustomTable_MainID ,ColumnName ,Enum_CustomTable_ColumnType) ");
                int insertCnt = 0;
                //修改的字段sql
                StringBuilder updateSql = new StringBuilder();
                foreach (var item in Json)
                {

                    if (item.ID != 0)
                    {
                        //获取修改后还保留的ID
                        jsonIDs.Append(item.ID + ",");
                        //拼接修改的数据
                        updateSql.AppendFormat(" Update CustomTable_Column set ColumnName='{0}',Enum_CustomTable_ColumnType={1} where ID = {2}  ", item.Option, item.TypeVal, item.ID);
                    }
                    //拼接新增的数据
                    if (item.ID == 0)
                    {
                        insertSql.AppendFormat(" SELECT {0},'{1}','{2}' UNION ALL", ct_m.ID, item.Option, item.TypeVal);
                        insertCnt++;
                    }



                }
                //去掉修改后还保留的ID多余的“，”
                var IDs = jsonIDs.ToString().TrimEnd(',');
                //去掉新增的字段sql多余的“UNION ALL”
                var AddSql = insertSql.ToString();
                AddSql = AddSql.Remove(AddSql.Length - " UNION ALL".Length);

                //删除数据
                string delSql = string.Format(" Delete CustomTable_Values where CustomTable_MainID={0} and CustomTable_ColumnID not in ({1}) "
                                            + " Delete CustomTable_Column where CustomTable_MainID={0} and ID not in ({1})", ct_m.ID, IDs);
                base.SqlExecute(delSql);
                //添加新增数据
                if (insertCnt > 0)
                {
                    base.SqlExecute(AddSql);
                }
                //修改数据
                base.SqlExecute(updateSql.ToString());

                trans.Complete();
            }
            return result;
        }

        /// <summary>
        /// 删除主表数据
        /// </summary>
        /// <param name="CMID"></param>
        /// <returns></returns>
        public Result Delete_CustomMain(int CMID)
        {
            Result result = new Result();
            using (System.Transactions.TransactionScope trans = new System.Transactions.TransactionScope())
            {
                CustomTable_ValuesModel CM_Vmodel = new CustomTable_ValuesModel();
                CM_Vmodel.DelCustomVal_BYCMID(CMID);
                CustomTable_ColumnModel CM_Cmodle = new CustomTable_ColumnModel();
                CM_Cmodle.DelCustomColumn_BYCMID(CMID);
                base.Delete(CMID);
                trans.Complete();
            }
            return result;
        }

    }
}
