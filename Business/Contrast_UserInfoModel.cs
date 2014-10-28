using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Business
{
    public class Contrast_UserInfoModel : BaseModel<Contrast_UserInfo>
    {
        public List<User_Organization> UserContrast()
        {
            OrganizationModel om = new OrganizationModel();
            var query = from a in Context.Contrast_UserInfo
                        from b in Context.Contrast_Organization
                        where a.DemandMoney <= b.ProvideMoney &&
                              a.DemandMonth >= b.BeginMonth && a.DemandMonth <= b.EndMonth &&
                              a.AcceptInterest <= b.DemandInterest
                        select new User_Organization { user = a, org = b };
            return query.ToList();
        }

    }
}
