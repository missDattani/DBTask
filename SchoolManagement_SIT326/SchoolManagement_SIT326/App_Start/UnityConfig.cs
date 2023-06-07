using SchoolManagement_SIT326.Repositories.Repository;
using SchoolManagement_SIT326.Repositories.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace SchoolManagement_SIT326
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
            container.RegisterType<ICountryInterface, CountryRepository>();
            container.RegisterType<IStateInterface, StateRepository>();
            container.RegisterType<ICityInterface, CityRepository>();
            container.RegisterType<ISubjectInterface, SubjectRepository>();
            container.RegisterType<ITeacherInterface, TeacherRepository>();
            container.RegisterType<IStudentInterface, StudentRepository>();



            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}