using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem326.Services.JWTAuthentication
{
    public interface IJWTAuthServices
    {
        string GenerateToken(string Email,string UserId,string SecretKey,double JWT_Validity_Mins);
    }
}
