using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace PruebaTecnica.Application.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);

            // Fluent Validation Configurations
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // DI MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // Auto Mapper Configurations
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
