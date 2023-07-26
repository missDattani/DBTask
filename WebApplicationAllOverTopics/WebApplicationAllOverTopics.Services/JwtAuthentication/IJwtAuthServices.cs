using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationAllOverTopics.Services.JwtAuthentication
{
    public interface IJwtAuthServices
    {
        string GenerateToken(string Email,string RoleName,string SecretKey,double Jwt_Validate_Min);
    }
}
