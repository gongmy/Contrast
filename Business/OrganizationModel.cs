using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data;

namespace Business
{
    public class OrganizationModel : BaseModel<Contrast_Organization>
    {

        public DataTable GetContrastInfo()
        {
            string sql = @"select a.Name,a.ProvideMoney,a.BeginMonth,a.EndMonth,a.DemandInterest,b.CompanyName,b.DemandMoney,b.DemandMonth,b.AcceptInterest from Contrast_Organization a ,Contrast_UserInfo b 
                    where  a.ProvideMoney >=b.DemandMoney and a.BeginMonth <= b.DemandMonth  and  a.EndMonth >= b.DemandMonth and a.DemandInterest<=b.AcceptInterest";
            var date = SqlHelper.ExecuteDataset(sql);
            return date.Tables[0];
        }
    }
}
