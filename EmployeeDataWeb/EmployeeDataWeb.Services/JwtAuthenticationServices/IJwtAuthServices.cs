using EmployeeDataWeb.Model.ViewModels.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataWeb.Services.JwtAuthenticationServices
{
    public interface IJwtAuthServices
    {
        string GetJwtToken(string Email,string Id,string SecretKey, double Jwt_Validity_Min);

        UserTokenData GetUserTokenData(string jwtToken);
    }
}
