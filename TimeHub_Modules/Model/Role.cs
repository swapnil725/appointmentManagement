using System;
using System.Collections.Generic;
using System.Text;
using TimeHub_Modules.Enums;

namespace TimeHub_Modules.Model
{
    public class Role : BaseModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public UserType UserTypeId { get; set; }
    }

    public class UserRoleMapping : BaseModel
    {
        public string UserRoleMappingId { get; set; }
        public string RoleId { get; set; }
        public string UserId { get; set; }
    }
}
