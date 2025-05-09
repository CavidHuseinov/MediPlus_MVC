
using FluentValidation;
using MediPlus.Application.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MediPlus.Application
{
    public static class ApplicationServiceInstaller
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
