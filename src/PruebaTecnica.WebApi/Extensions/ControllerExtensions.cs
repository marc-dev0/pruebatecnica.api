using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace PruebaTecnica.WebApi.Extensions
{
    public static class ControllerExtensions
    {
        public static IServiceCollection AddControllerVersion(this IServiceCollection services)
        {
            services
                .AddControllersWithViews(config =>
                {
                    config.Conventions.Add(new ApiExplorerGroupPerVersionConvention());
                });

            return services;
        }

        private class ApiExplorerGroupPerVersionConvention : IControllerModelConvention
        {
            public void Apply(ControllerModel controller)
            {
                var controllerNamespace = controller.ControllerType.Namespace;
                var apiVersion = controllerNamespace?.Split('.').Last().ToLower();

                controller.ApiExplorer.GroupName = apiVersion;
            }
        }
    }
}
