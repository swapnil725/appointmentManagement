using Dapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeHub_DAT.DBContext;
using TimeHub_DAT.RepoInterface;
using TimeHub_Modules;
using TimeHub_Modules.Enums;
using TimeHub_Modules.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TimeHub_DAT.RepoServices
{
    public class UserData : IUserData
    {
        private readonly DapperDBContext _context;
        public UserData(DapperDBContext context)
        {
            _context = context;
        }
        public async Task<User> CreateUser(User user)
        {
            var oldUser = new User();
            user.UserId = Guid.NewGuid().ToString();
            user.CreatedBy = Guid.NewGuid().ToString();
            user.ModifiedBy = Guid.NewGuid().ToString();
            user.CreatedDate = DateTime.Now;
            user.ModifiedDate = DateTime.Now;
            if (user.UserTypeId != UserType.User)
            {
                user.IsActive = false;
            }
            var parameters = new DynamicParameters();
            parameters.Add("UserId", user.UserId, DbType.Guid);
            parameters.Add("FirstName", user.FirstName, DbType.String);
            parameters.Add("LastName", user.LastName, DbType.String);
            parameters.Add("EmailAddress", user.EmailAddress.ToLower(), DbType.String);
            parameters.Add("MobileNo", user.MobileNo, DbType.String);
            parameters.Add("UserPassword", user.UserPassword, DbType.String);
            parameters.Add("Address", user.Address, DbType.String);
            parameters.Add("UserTypeId", user.UserTypeId, DbType.Int32);
            parameters.Add("IsActive", user.IsActive, DbType.Boolean);
            parameters.Add("CreatedDate", user.CreatedDate, DbType.DateTime);
            parameters.Add("ModifiedDate", user.ModifiedDate, DbType.DateTime);
            parameters.Add("CreatedBy", user.CreatedBy, DbType.Guid);
            parameters.Add("ModifiedBy", user.ModifiedBy, DbType.Guid);

            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var userDataByEmail = new DynamicParameters();
                    userDataByEmail.Add("p_EmailAddress", user.EmailAddress, DbType.String);
                    oldUser = await connection.QuerySingleAsync<User>("TH_SP_GetUserByEmail", userDataByEmail, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString() + " /n " + ex.InnerException.Message);
                }
                finally
                {
                    if (oldUser?.UserId == null)
                    {
                        var res = await connection.ExecuteAsync("TH_SP_CreateUser", parameters, commandType: CommandType.StoredProcedure);
                        if (res != 1)
                        {
                            user = null;
                        }
                    }
                    else
                    {
                        user = null;
                    }
                }
                connection.Close();
            }
            return user;
        }

        public async Task<bool> DeleteUserById(string id)
        {
            var res = false;
            var parameters = new DynamicParameters();
            parameters.Add("p_UserId", id, DbType.Guid);
            using (var connection = _context.CreateConnection())
            {
                var deletedUser = await connection.ExecuteAsync("TH_SP_DeleteUserById", parameters, commandType: CommandType.StoredProcedure);
                if (deletedUser == 1) res = true;
                connection.Close();
            }
            return res;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<User>("TH_SP_GetAllUser", commandType: CommandType.StoredProcedure);
                connection.Close();
                if (users.Any())
                {
                    users = users.Where(x => x.IsActive == true);
                    return users;
                }
                return null;
            }
        }

        public async Task<User> GetUserById(string EmailId)
        {
            var user = new User();
            var parameters = new DynamicParameters();
            parameters.Add("p_EmailAddress", EmailId.ToLower(), DbType.String);
            using (var connection = _context.CreateConnection())
            {
                try
                {
                    user = await connection.QuerySingleAsync<User>("TH_SP_GetUserByEmail", parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (user?.UserId == null || user?.IsActive == false) user = null;
                    connection.Close();
                }
            }
            return user;
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
