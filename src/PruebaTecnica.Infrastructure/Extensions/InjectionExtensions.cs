using PruebaTecnica.Infrastructure.Persistences.Contexts;
using PruebaTecnica.Infrastructure.Persistences.Interfaces;
using PruebaTecnica.Infrastructure.Persistences.Repositories;
using PruebaTecnica.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client.Core.DependencyInjection;

namespace PruebaTecnica.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            //services.AddScoped<INotify, Notify>();

            /*var rabbitMqSection = configuration.GetSection("RabbitMq");
            var exchangeSection = configuration.GetSection("RabbitMqExchange");

            services.AddRabbitMqProducingClientTransient(rabbitMqSection)
                .AddProductionExchange("exchange.name", exchangeSection);*/

            return services;
        }
    }
}
