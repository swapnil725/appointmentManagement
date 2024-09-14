﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeHub_Modules.Model;

namespace TimeHub_BAT.Interfaces
{
    public interface IUserService
    {
        public Task<User> CreateUser(User user);
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User> UpdateUser(User user);
        public Task<User> GetUserById(string id);
        public Task<bool> DeleteUserById(string id);
    }
}
