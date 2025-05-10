using MediPlus.Application;
using MediPlus.Domain.Settings;
using MediPlus.Infrastructure;
using MediPlus.Persistance;

namespace MediPlus.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            PersistanceServiceInstaller.AddPersistaneService(builder.Services, builder.Configuration);
            ApplicationServiceInstaller.AddApplicationService(builder.Services);
            PersistanceServiceInstaller.AddDIRepositories(builder.Services);
            InfrastructureInstallerService.AddDIServices(builder.Services);
            builder.Services.Configure<CacheSettings>(builder.Configuration.GetSection("CacheSettings"));



            var app = builder.Build();
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.UseStaticFiles();
            app.Run();
        }
    }
}
