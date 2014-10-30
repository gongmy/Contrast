using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Business
{
    public class Contrast_AccountModel : BaseModel<Contrast_Account>
    {
        public Contrast_Account Login(string loginName, string password)
        {
            return List().Where(a => a.LoginName.Equals(loginName, StringComparison.CurrentCultureIgnoreCase) && a.Password.Equals(password, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
        }
    }
}
