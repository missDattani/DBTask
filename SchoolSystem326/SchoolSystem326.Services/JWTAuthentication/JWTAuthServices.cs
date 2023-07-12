using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolSystem326.Services.JWTAuthentication
{
    public class JWTAuthServices : IJWTAuthServices
    {
        public string GenerateToken(string Email, string UserId, string SecretKey, double JWT_Validity_Mins)
        {
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Email", Email),
                    new Claim("UserId",UserId)

                }),

                Expires = DateTime.Now.AddMinutes(JWT_Validity_Mins),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey)), SecurityAlgorithms.HmacSha256Signature),
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }
    }
}

