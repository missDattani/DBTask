using ProfileUpload.Data;
using ProfileUpload.Data.DBRepository;
using ProfileUpload.Services;

namespace ProfileUpload
{
    public static class RegisterServices
    {
        public static void RegisterService(this IServiceCollection collection)
        {
            Configure(collection, DataRegister.GetTypes());
            Configure(collection, SreviceRegister.GetTypes());

        }
        public static void Configure(IServiceCollection services,Dictionary<Type,Type> dictionary)
        {
            foreach(var item in dictionary)
            {
                services.AddScoped(item.Key, item.Value);
            }
            services.AddMvc();
            services.AddHttpContextAccessor();
             services.AddControllersWithViews();
            //services.AddSingleton(Configuration);
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
