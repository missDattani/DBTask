using EmployeeDataWeb.Data;
using EmployeeDataWeb.Services;

namespace EmployeeDataWeb
{
    public static class RegisterServices
    {
        public static void RegisterService(this IServiceCollection services)
        {
            Configure(services,DataRegister.GetTypes());
            Configure(services,ServiceRegister.GetTypes());
        }
        public static void Configure(IServiceCollection services,Dictionary<Type,Type> dictionary)
        {
            foreach (var item in dictionary)
            {
                services.AddScoped(item.Key, item.Value);
            }

            services.AddSession();
            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddMvc();
            services.AddHttpContextAccessor();
        }
    }
}
