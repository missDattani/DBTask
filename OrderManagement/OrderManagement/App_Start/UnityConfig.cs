using OrderManagement.Repositories.Repositories;
using OrderManagement.Repositories.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace OrderManagement
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserInterface, UserRepository>();
            container.RegisterType<IOrderInterface, OrderRepository>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}