using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegister.Models.Context;

namespace UserRegister.Models.Models
{
    public class UserPageModel
    {
       
            public List<User> Users { get; set; }

            public int CurrentPageIndex { get; set; }

            public int PageCount { get; set; }
        
    }
}
