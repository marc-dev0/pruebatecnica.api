using MediatR;
using PruebaTecnica.Application.Commons;

namespace PruebaTecnica.Application.Services.Categoria.Commands.InsUpdCategoriaCommand
{
    public class InsUpdCategoriaCommand : IRequest<Response<bool>>
    {
        public int IdCategoria { get; set; }
        public int IdUsuario { get; set; }
        public string Descripcion { get; set; }
        public string NombreCorto { get; set; }
        public bool Estado { get; set; }
    }
}
