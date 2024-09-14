using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeHub_Modules.Model;

namespace TimeHub_BAT.Interfaces
{
    public interface IUserRoleService
    {
        public Task<Role> CreateUserRole(Role userRole);
        public Task<IEnumerable<Role>> GetAllUsersRole();
        public Task<Role> UpdateUserRole(User user);
        public Task<Role> GetUserRoleById(string id);
        public bool DeleteUserRoleById(string id);
    }
}
