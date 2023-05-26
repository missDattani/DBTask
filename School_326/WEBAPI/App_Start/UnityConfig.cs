using School_326.Repository.Repository;
using School_326.Repository.Services;
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
            container.RegisterType<ICountryInterface, CountryRepository>();
            container.RegisterType<IStateInterface, StateRepository>();
            container.RegisterType<ICityInterface, CityRepository>();
            container.RegisterType<ISubjectInterface, SubjectRepository>();
            container.RegisterType<ITeacherInterface, TeacherRepository>();
            container.RegisterType<IStudentInterface, StudentRepository>();





            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}