using PruebaTecnica.Application.Commons;
using MediatR;

namespace PruebaTecnica.Application.Services.Usuarios.Commands.AddUsuarioCommand
{
    public class AddUsuarioCommand : IRequest<Response<bool>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
