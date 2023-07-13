using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiCoreRepos.Model.ViewModel
{
    public class JWTAuthenticationModel
    {
        public string SecretKey { get; set; }

        public int ValidateMin { get;set; }
    }
}
