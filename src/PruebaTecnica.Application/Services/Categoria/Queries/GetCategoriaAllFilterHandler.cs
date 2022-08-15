using AutoMapper;
using MediatR;
using PruebaTecnica.Application.Commons;
using PruebaTecnica.Application.Dtos;
using PruebaTecnica.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Services.Categoria.Queries
{
    public class GetCategoriaAllFilterHandler : IRequestHandler<GetCategoriaAllFilterQuery, Response<IEnumerable<GetCategoriaAllFilterViewModel>>>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public GetCategoriaAllFilterHandler(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetCategoriaAllFilterViewModel>>> Handle(GetCategoriaAllFilterQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<GetCategoriaAllFilterViewModel>>();
            try
            {
                var categoria = await _categoriaRepository.GetAllFilterAsync(request.Descripcion);
                if (categoria is not null)
                {
                    response.Data = _mapper.Map<List<GetCategoriaAllFilterViewModel>>(categoria);
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                }   
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
