using QuizApplication.Repositories.Repositories;
using QuizApplication.Repositories.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace QuizApplication
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserInterface, UserServices>();
            container.RegisterType<IQuizInterface, QuizServices>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}