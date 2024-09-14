using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeHub_Modules.Model;

namespace TimeHub_DAT.RepoInterface
{
    public interface IUserRoleData
    {
        public Task<Role> CreateUserRole(Role userRole);
        public Task<IEnumerable<Role>> GetAllUsersRole();
        public Task<Role> UpdateUserRole(User user);
        public Task<Role> GetUserRoleById(string id);
        public Task<bool> DeleteUserRoleById(string id);
    }
}
