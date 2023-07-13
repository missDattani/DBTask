using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiCoreRepos.Services.JwtAuthentication
{
    public interface IJWTAuthServices
    {
        string GenerateJwtToken(string Email,string UserId,string SecretKey,double Jwt_Validate_Min);
    }
}
