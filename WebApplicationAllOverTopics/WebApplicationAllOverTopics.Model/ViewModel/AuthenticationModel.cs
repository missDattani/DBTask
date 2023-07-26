using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationAllOverTopics.Model.ViewModel
{
    public class AuthenticationModel
    {
        public string SecretKey { get; set; }

        public int ValidateMin { get; set; }
    }
}
