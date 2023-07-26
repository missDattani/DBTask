using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;

namespace EmployeeDataWeb.Filter
{
    public class JwtTokenFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string userJwtToken = context.HttpContext.Session.GetString("userToken");

            if(!string.IsNullOrEmpty(userJwtToken) )
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken securityToken = tokenHandler.ReadToken(userJwtToken) as JwtSecurityToken;
                if( securityToken != null )
                {
                    if(securityToken.ValidTo < DateTime.UtcNow.AddMinutes(1))
                    {
                        context.HttpContext.Session.Clear();
                        context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            action = "Login",
                            controller = "User",
                            //returnUrl = context.HttpContext.Request.Path.Value
                        }));
                    }
                }
            }
            else
            {
                context.HttpContext.Session.Clear();
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    action = "Login",
                    controller = "User",
                   // returnUrl = context.HttpContext.Request.Path.Value
                }));
            }
        }
    }
}
