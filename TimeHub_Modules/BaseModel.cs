﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TimeHub_Modules
{
    public class BaseModel
    {
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
