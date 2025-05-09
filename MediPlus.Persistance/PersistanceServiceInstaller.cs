using MediPlus.Domain.IRepositories;
using MediPlus.Domain.IRepositories.Generics;
using MediPlus.Persistance.Context;
using MediPlus.Persistance.Repositories;
using MediPlus.Persistance.Repositories.Generics;
using MediPlus.Persistance.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediPlus.Persistance
{
    public static class PersistanceServiceInstaller
    {
        public static void AddPersistaneService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<MediPlusDb>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("Default"));
            });
        }

        public static void AddDIRepositories(this IServiceCollection services)
        {
            #region Generics 
            services.AddScoped(typeof(IQueryRepo<>), typeof(QueryRepo<>));
            services.AddScoped(typeof(ICommandRepo<>), typeof(CommandRepo<>));
            #endregion

            #region UnitOfWorks
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Repositories
            services.AddScoped<ISliderRepo, SliderRepo>();
            #endregion
        }
    }
}
