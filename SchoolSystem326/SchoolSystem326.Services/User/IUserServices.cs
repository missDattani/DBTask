﻿using SchoolSystem326.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem326.Services.User
{
    public interface IUserServices
    {
        Task<UserModel> LoginUser(LoginModel loginModel);
         Task<int> RegisterUser(UserModel userModel);
        Task<UserModel> GetUserById(int id);

        Task<List<UserModel>> GetAllUsers();
    }
}
