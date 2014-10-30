﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Business
{
    public class Contrast_WorkflowModel : BaseModel<Contrast_Workflow>
    {
        public List<Contrast_Workflow> GetList()
        {
            return List().OrderBy(a => a.Sort).ToList();
        }
    }
}
