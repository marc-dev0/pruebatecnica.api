using PruebaTecnica.Application.Commons;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Application.Services.Usuarios.Commands.AddTokenCommand
{
    public class AddTokenCommand : IRequest<Response<string>>
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
