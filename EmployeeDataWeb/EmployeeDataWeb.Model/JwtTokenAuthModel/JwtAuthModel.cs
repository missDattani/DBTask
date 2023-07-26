using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataWeb.Model.JwtTokenAuthModel
{
    public class JwtAuthModel
    {
        public string SecretKey { get; set; }
        public int ValidateMin { get; set; }
    }
}
