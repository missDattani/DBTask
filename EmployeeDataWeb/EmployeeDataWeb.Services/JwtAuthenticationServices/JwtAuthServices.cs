using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using EmployeeDataWeb.Model.ViewModels.Token;
using Newtonsoft.Json;

namespace EmployeeDataWeb.Services.JwtAuthenticationServices
{
    public class JwtAuthServices : IJwtAuthServices
    {
        public string GetJwtToken(string Email, string Id, string SecretKey, double Jwt_Validity_Min)
        {
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Email", Email),
                    new Claim("Id", Id)
                }),
                Expires = DateTime.Now.AddMinutes(Jwt_Validity_Min),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey)), SecurityAlgorithms.HmacSha256Signature)

            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }

        public UserTokenData GetUserTokenData(string jwttoken)
        {
            try
            {
                UserTokenData usertoken = new UserTokenData();
                JwtSecurityTokenHandler tokenhandler = new JwtSecurityTokenHandler();
                JwtSecurityToken securitytoken = (JwtSecurityToken)tokenhandler.ReadToken(jwttoken);
                IEnumerable<Claim> claims = securitytoken.Claims;

                if (claims != null && claims.ToList().Count > 0)
                {
                    var claimdata = claims.ToList();
                 
                    usertoken.Id = Convert.ToInt32(claimdata[1].Value);
                    usertoken.TokenValidTo = securitytoken.ValidTo;
                }
                return usertoken;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
