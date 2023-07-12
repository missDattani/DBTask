using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem326.Model.ViewModels
{
    public class JWTAuthenticationModel
    {
        public string SecretKey { get; set; }
        public int ValidateMin { get; set; }

        public DateTime ExpiresOn { get; set; }

        public long UserId { get; set; }
    }
}
