using StudentResultManagement.Repositories.Repositories;
using StudentResultManagement.Repositories.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace StudentResultManagement
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IStudentInterface, StudentServices>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}