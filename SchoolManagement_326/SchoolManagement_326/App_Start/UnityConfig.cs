using SchoolMgmt_326.Repositories.Repositories;
using SchoolMgmt_326.Repositories.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace SchoolManagement_326
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

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}