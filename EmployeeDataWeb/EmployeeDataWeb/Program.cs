using EmployeeDataWeb.Middleware;
using EmployeeDataWeb.Model.JwtTokenAuthModel;
using EmployeeDataWeb.Model.ViewModels.SMTPSettings;
using EmployeeDataWeb.Services.JwtAuthenticationServices;

namespace EmployeeDataWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.RegisterService();
            builder.Services.Configure<JwtAuthModel>(builder.Configuration.GetSection("JWTAuthentication"));
            builder.Services.Configure<SMTPSettings>(builder.Configuration.GetSection("SMTPSettings"));
            builder.Services.AddSingleton<IJwtAuthServices,JwtAuthServices>();
            builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseMiddleware<CustomMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=User}/{action=Login}/{id?}");

            app.Run();
        }
    }
}