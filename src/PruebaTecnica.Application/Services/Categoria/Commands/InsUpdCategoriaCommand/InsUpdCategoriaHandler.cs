using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PruebaTecnica.Application.Commons;
using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Services.Categoria.Commands.InsUpdCategoriaCommand
{
    public class InsUpdCategoriaHandler : IRequestHandler<InsUpdCategoriaCommand, Response<bool>>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<InsUpdCategoriaHandler> _logger;
        public InsUpdCategoriaHandler(ICategoriaRepository categoriaRepository, IMapper mapper, ILogger<InsUpdCategoriaHandler> logger)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<bool>> Handle(InsUpdCategoriaCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            try
            {
                var categoria = _mapper.Map<Categorias>(request);
                response.Data = await _categoriaRepository.InsertUpdateAsync(categoria);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro exitoso";
                    _logger.LogInformation(response.Message);
                }
                else
                {
                    _logger.LogInformation(response.Message);
                    response.Message = "Registro fallido";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, response.Message);
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
