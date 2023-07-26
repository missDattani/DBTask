﻿using SchoolMgmt_System.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_System.Services.Users
{
    public interface IUserServices
    {
        Task<UserModel> LoginUser(LoginModel loginModel);
        Task<UserModel> CheckUser(UserModel userModel);
        Task<int> RegisterUser(UserModel userModel);

        Task<ForgotData> GetUserDetailsByEmail(ForgotData userData); 
    }
}
