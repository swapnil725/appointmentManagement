using System;
using System.Collections.Generic;
using System.Text;
using TimeHub_Modules.Enums;

namespace TimeHub_Modules.Model
{
    public class User : BaseModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNo { get; set; }
        public string UserPassword { get; set; }
        public string Address { get; set; }
        public UserType UserTypeId { get; set; }

    }
}
