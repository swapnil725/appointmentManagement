using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeHub_BAT.Interfaces;
using TimeHub_DAT.RepoInterface;
using TimeHub_Modules.Model;

namespace TimeHub_BAT.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleData _userRoleData;

        public UserRoleService(IUserRoleData userRoleData)
        {
            _userRoleData = userRoleData;
        }
        public Task<Role> CreateUserRole(Role userRole)
        {
            return _userRoleData.CreateUserRole(userRole);
        }

        public bool DeleteUserRoleById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Role>> GetAllUsersRole()
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetUserRoleById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Role> UpdateUserRole(User user)
        {
            throw new NotImplementedException();
        }
    }
}
