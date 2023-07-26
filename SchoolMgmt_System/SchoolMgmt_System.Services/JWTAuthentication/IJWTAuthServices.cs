using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_System.Services.JWTAuthentication
{
    public interface IJWTAuthServices
    {
        string GenerateJwtToken(string Email, string UserId, string SecretKey, double JWT_Validity_Min);
    }
}
