using SchoolMgmt_326.Repositories.Repositories;
using SchoolMgmt_326.Repositories.Services;
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
            container.RegisterType<IUserInterface, UserService>();
            container.RegisterType<IStudentInterface, StudentServices>();
            container.RegisterType<ISubjectInterface, SubjectService>();
            container.RegisterType<ICountryInterface, CountryServices>();
            container.RegisterType<IStateInterface, StateServices>();
            container.RegisterType<ICityInterface, CityServices>();
            container.RegisterType<ITeacherInterface, TeacherServices>();


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}