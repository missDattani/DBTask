﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_SIT326.Helpers.GlobalEnum
{
    public enum GenderEnum
    {
        [Display(Name = "Male")]
        Male = 1,
        [Display(Name = "Female")]
        Female = 2,
        [Display(Name = "Other")]
        Other = 3
    }
}
