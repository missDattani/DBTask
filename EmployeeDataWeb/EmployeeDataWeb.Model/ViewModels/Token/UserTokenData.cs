using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataWeb.Model.ViewModels.Token
{
    public class UserTokenData
    {
        public int Id { get; set; }
        public DateTime TokenValidTo { get; set; }
        public string Email { get; set; }
    }
}
