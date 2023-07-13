using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace WebApiCoreRepos.Services.JwtAuthentication
{
    public class JWTAuthServices : IJWTAuthServices
    {
        public string GenerateJwtToken(string Email, string UserId, string SecretKey, double Jwt_Validate_Min)
        {
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Email", Email),
                    new Claim("Id", UserId)
                }),

                Expires = DateTime.Now.AddMinutes(Jwt_Validate_Min),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey)), SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);

        }
    }
}
