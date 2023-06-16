using SchoolMgmtWEB_326.Repository.Repositories;
using SchoolMgmtWEB_326.Repository.Services;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace WEBAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICountryInterface, CountryService>();
            container.RegisterType<IUserInterface, UserServices>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}