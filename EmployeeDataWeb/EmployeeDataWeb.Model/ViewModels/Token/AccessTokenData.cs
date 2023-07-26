using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataWeb.Model.ViewModels.Token
{
    public class AccessTokenData
    {
        public string Token { get; set; }
        public int ValidityMin { get; set; }    
        public DateTime ExpiresOnUtc { get; set; }
        public int Id { get; set; }
    }
}
