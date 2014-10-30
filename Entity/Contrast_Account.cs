using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Contrast_Account : BaseEntity
    {
        public int ID { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Contrast_Workflow> Contrast_Workflows { get; set; }

        public virtual ICollection<Contrast_WorkflowMain> Contrast_WorkflowMains { get; set; }
    }
}
