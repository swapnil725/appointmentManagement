using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using TimeHub_DAT.DBContext;
using TimeHub_DAT.RepoInterface;
using TimeHub_Modules.Model;

namespace TimeHub_DAT.RepoServices
{
    public class UserRoleData : IUserRoleData
    {
        private readonly DapperDBContext _context;
        public UserRoleData(DapperDBContext context)
        {
            _context = context;
        }
        public async Task<Role> CreateUserRole(Role userRole)
        {
            userRole.RoleId = Guid.NewGuid().ToString();
            userRole.CreatedBy = Guid.NewGuid().ToString();
            userRole.ModifiedBy = Guid.NewGuid().ToString();
            userRole.CreatedDate = DateTime.Now;
            userRole.ModifiedDate = DateTime.Now;
            var parameters = new DynamicParameters();
            parameters.Add("RoleId", userRole.RoleId, DbType.Guid);
            parameters.Add("RoleName", userRole.RoleName, DbType.String);
            parameters.Add("UserTypeId", userRole.UserTypeId, DbType.Int32);
            parameters.Add("IsActive", userRole.IsActive, DbType.Boolean);
            parameters.Add("CreatedDate", userRole.CreatedDate, DbType.DateTime);
            parameters.Add("ModifiedDate", userRole.ModifiedDate, DbType.DateTime);
            parameters.Add("CreatedBy", userRole.CreatedBy, DbType.Guid);
            parameters.Add("ModifiedBy", userRole.ModifiedBy, DbType.Guid);
            using (var connection = _context.CreateConnection())
            {
                var res = await connection.ExecuteAsync("TH_SP_CreateRole", parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                if (res == 1)
                {
                    return userRole;
                }
            }
            return null;
        }

        public async Task<bool> DeleteUserRoleById(string id)
        {
            var res = false;
            var parameters = new DynamicParameters();
            parameters.Add("p_RoleId", id, DbType.Guid);
            using (var connection = _context.CreateConnection())
            {
                var deletedUserRole = await connection.ExecuteAsync("TH_SP_DeleteRoleById", parameters, commandType: CommandType.StoredProcedure);
                if (deletedUserRole == 1) res = true;
                connection.Close();
            }
            return res;
        }

        public Task<IEnumerable<Role>> GetAllUsersRole()
        {
            throw new NotImplementedException();
        }

        public async Task<Role> GetUserRoleById(string id)
        {
            var role = new Role();
            var parameters = new DynamicParameters();
            parameters.Add("p_RoleId", id, DbType.Guid);
            using (var connection = _context.CreateConnection())
            {
                try
                {
                    role = await connection.QuerySingleAsync<Role>("TH_SP_GetUserRoleById", parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (role?.RoleId == null || role?.IsActive == false) role = null;
                    connection.Close();
                }
            }
            return role;
        }

        public Task<Role> UpdateUserRole(User user)
        {
            throw new NotImplementedException();
        }
    }
}
