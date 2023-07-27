using TrainingCoreProject.Data;
using TrainingCoreProject.Services;

namespace TrainingCoreProject
{
    public static class RegisterServices
    {
        public static void RegisterService(this IServiceCollection service)
        {
            Configure(service, DataRegister.GetTypes());
            Configure(service,ServiceRegister.GetTypes());
        }
        public static void Configure(IServiceCollection services,Dictionary<Type,Type> dictionary)
        {
            foreach(var item in dictionary)
            {
                services.AddScoped(item.Key, item.Value);
            }

            services.AddMvc();
            services.AddHttpContextAccessor();
        }

        
    }
}
