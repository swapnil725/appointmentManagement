using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeHub_BAT.Interfaces;
using TimeHub_DAT.RepoInterface;
using TimeHub_Modules.Enums;
using TimeHub_Modules.Model;

namespace TimeHub_BAT.Services
{
    public class UserService : IUserService
    {
        private readonly IUserData _userData;
        private readonly IEmailService _emailService;
        public UserService(IUserData userData, IEmailService emailService)
        {
            _userData = userData;
            _emailService = emailService;
        }
        public async Task<User> CreateUser(User user)
        {
            var CreateUser = await _userData.CreateUser(user);
            if (CreateUser != null && user.UserTypeId != UserType.User)
            {
                // here call function to send email with link to verify email address;
                var httpResponse = await _emailService.SendEmailAsync(user);
            }
            return CreateUser;
        }

        public Task<bool> DeleteUserById(string id)
        {
            return _userData.DeleteUserById(id);
        }

        public Task<IEnumerable<User>> GetAllUsers()
        {
            return _userData.GetAllUsers();
        }

        public Task<User> GetUserById(string id)
        {
            return _userData.GetUserById(id);
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
