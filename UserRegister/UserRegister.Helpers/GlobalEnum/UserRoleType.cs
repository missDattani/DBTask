using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRegister.Helpers.GlobalEnum
{
    public enum UserRoleType
    {
        [Display(Name = "Super Admin")]
        SuperAdmin = 1,
        [Display(Name = "Admin")]
        Admin = 2,
        [Display(Name = "User")]
        User = 3
    }
}
