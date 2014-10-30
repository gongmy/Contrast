using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    [Serializable]
    public class SessionLoginUser
    {
        public int ID { get; set; }

        public Contrast_Account Contrast_Account { get; set; }
    }
}
