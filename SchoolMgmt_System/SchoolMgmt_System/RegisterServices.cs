using SchoolMgmt_System.Data;
using SchoolMgmt_System.Services;

namespace SchoolMgmt_System
{
    public static class RegisterServices
    {
        public static void RegisterService(this IServiceCollection services)
        {
            Configure(services, DataRegister.GetTypes());
            Configure(services, ServiceRegister.GetTypes());
        }

        private static void Configure(IServiceCollection services, Dictionary<Type, Type> dictionary)
        {
            foreach (var type in dictionary)
            {
                services.AddScoped(type.Key, type.Value);
            }

            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession();
            services.AddMvc();
            services.AddHttpContextAccessor();
        }
    }
}
