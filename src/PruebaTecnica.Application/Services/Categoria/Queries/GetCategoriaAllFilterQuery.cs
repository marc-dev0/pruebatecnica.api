using MediatR;
using PruebaTecnica.Application.Commons;
using System.Collections.Generic;

namespace PruebaTecnica.Application.Services.Categoria.Queries
{
    public class GetCategoriaAllFilterQuery : IRequest<Response<IEnumerable<GetCategoriaAllFilterViewModel>>>
    {
        public string Descripcion { get; set; }
    }
}
