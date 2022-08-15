using Microsoft.VisualStudio.TestTools.UnitTesting;
using PruebaTecnica.WebApi;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using PruebaTecnica.Application.Dtos;
using System.Threading.Tasks;
using MediatR;
using PruebaTecnica.Application.Services.Usuarios.Commands.AddTokenCommand;

namespace PruebaTecnica.Test
{
    [TestClass]
    public class AccountApplicationTest
    {
        private static IConfiguration _configuration;
        private static IServiceScopeFactory _scopeFactory;

        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .AddEnvironmentVariables();

            _configuration = builder.Build();
            _configuration.GetConnectionString("CRMConnection");

            var startup = new Startup(_configuration);
            var services = new ServiceCollection();
            startup.ConfigureServices(services);
            _scopeFactory = services.AddLogging().BuildServiceProvider().GetService<IServiceScopeFactory>();
        }

        [TestMethod]
        public async Task TokenAsync_CuandoSeEnviaValoresNulosOVacios_ErroresDeValidacion()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IMediator>();

            // Arrange
            var client = string.Empty;
            var secret = string.Empty;
            var expected = "Errores de Validación";

            // Act
            var result = await context.Send(new AddTokenCommand() { UserName = client, Password = secret });
            var actual = result.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task TokenAsync_CuandoSeEnviaValoresCorrectos_TokenExitoso()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IMediator>();

            // Arrange
            var client = "3sccc578s8spw";
            var secret = "0f8fad5b-d9cb-469f-a165-70867728950e";
            var expected = "Token Exitoso!!!";

            // Act
            var result = await context.Send(new AddTokenCommand() { UserName = client, Password = secret });
            var actual = result.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task TokenAsync_CuandoSeEnviaValoresIncorrectos_CuentaNoValida()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IMediator>();

            // Arrange
            var client = "3sccc578s8spwwwww";
            var secret = "0f8fad5b-d9cb-469f-a165-70867728950e";
            var expected = "Cuenta No Valida!!!";

            // Act
            var result = await context.Send(new AddTokenCommand() { UserName = client, Password = secret });
            var actual = result.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}