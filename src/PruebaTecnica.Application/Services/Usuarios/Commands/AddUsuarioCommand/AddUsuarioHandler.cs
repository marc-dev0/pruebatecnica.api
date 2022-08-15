using AutoMapper;
using PruebaTecnica.Application.Commons;
using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Infrastructure.Persistences.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace PruebaTecnica.Application.Services.Usuarios.Commands.AddUsuarioCommand
{
    public class AddUsuarioHandler : IRequestHandler<AddUsuarioCommand, Response<bool>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public AddUsuarioHandler(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(AddUsuarioCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            try
            {
                var account = _mapper.Map<Usuario>(request);
                //account.Password = BC.HashPassword(request.Password);

                response.Data = await _usuarioRepository.InsertAsync(account);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!!";
                }
                else
                {
                    response.Message = "Registro Fallido!!!";
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
