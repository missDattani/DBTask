using SchoolSystem326.Data;
using SchoolSystem326.Services;

namespace SchoolSystem326
{
    public static class RegisterServices
    {
        public static void RegisterService(this IServiceCollection services)
        {
            Configure(services, DataRegister.GetTypes());
            Configure(services, ServiceRegister.GetTypes());
        }

        public static void Configure(IServiceCollection services,Dictionary<Type,Type> types) 
        {
            foreach(var item in types)
            {
                services.AddScoped(item.Key, item.Value);
            }

            services.AddMvc();
            services.AddHttpContextAccessor();
            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession();
        }
    }
}
