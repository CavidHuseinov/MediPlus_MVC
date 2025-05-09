
using MediPlus.Domain.Interfaces.Services;
using MediPlus.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MediPlus.Infrastructure
{
    public static class InfrastructureInstallerService
    {
        public static void AddDIServices(this IServiceCollection services)
        {
            #region Services
            services.AddScoped<ISliderService, SliderService>();
            #endregion
        }
    }
}
