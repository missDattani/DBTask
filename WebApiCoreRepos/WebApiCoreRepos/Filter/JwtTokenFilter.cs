using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace WebApiCoreRepos.Filter
{

    public class JwtTokenFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string? userJWTToken = Convert.ToString(context.HttpContext.Session.GetString("userToken"));
            if (!string.IsNullOrEmpty(userJWTToken))
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                JwtSecurityToken? token = handler.ReadToken(userJWTToken) as JwtSecurityToken;
                if (token != null)
                {
                    if (token.ValidTo < DateTime.UtcNow.AddMinutes(1))
                    {
                        context.HttpContext.Session.Clear();
                        context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            action = "Login",
                            controller = "User"
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
                    controller = "User"
                }));
            }
        }
    }
}
