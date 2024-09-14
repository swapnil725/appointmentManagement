using System;
using System.Collections.Generic;
using System.Text;

namespace TimeHub_Modules.Model
{
    public class Firm : BaseModel
    {
        public string FirmId { get; set; }
    }

    public class UserFirmMapping : BaseModel
    {
        public string UserFirmMappingId { get; set; }
        public string UserId { get; set; }
        public string FirmId { get; set; }
    }
}
