using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client.Core.DependencyInjection.Services;

namespace PruebaTecnica.Infrastructure.Services
{
    public class Notify : INotify
    {
        private readonly IProducingService _producingService;

        public Notify(IProducingService producingService)
        {
            _producingService = producingService;
        }
        public async Task Publish(string message)
        {
            await _producingService.SendAsync(message, "exchange.name", "routing.key");
        }
    }
}
