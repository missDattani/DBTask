using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;

namespace WebApplicationAllOverTopics.Filter
{
    //Need only when program is without web api, to store token in localstorage
    public class JwtTokenFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string? userJwtToken = Convert.ToString(context.HttpContext.Session.GetString("userToken"));
            if(!string.IsNullOrEmpty(userJwtToken) )
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken? token = tokenHandler.ReadToken(userJwtToken) as JwtSecurityToken;
                if (token != null)
                {
                    if(token.ValidTo < DateTime.UtcNow.AddMinutes(1))
                    {
                        context.HttpContext.Session.Clear();
                        context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            action = "Login",
                            Controller = "User",
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
                    Controller = "User",
                }));
            }
        }
    }
}
