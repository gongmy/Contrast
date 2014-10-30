using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Business
{
    public class Contrast_WorkflowMainModel : BaseModel<Contrast_WorkflowMain>
    {
        public List<Contrast_WorkflowMain> GetList()
        {
            

            return null;
        }

        /// <summary>
        /// 查询我的申请
        /// </summary>
        /// <param name="AID">用户ID</param>
        /// <returns></returns>
        public List<Contrast_WorkflowMain> GetList_BYAccountID(int AID)
        {
            var list = List().Where(a => a.Contrast_AccountID == AID).OrderByDescending(a=>a.CreateTime).ToList();
            return list;
        }
    }
}
