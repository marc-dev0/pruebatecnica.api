using AutoMapper;
using PruebaTecnica.Application.Commons;
using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Infrastructure.Persistences.Interfaces;
using PruebaTecnica.Infrastructure.Services;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace PruebaTecnica.Application.Services.Usuarios.Commands.AddTokenCommand
{
    public class AddTokenHandler : IRequestHandler<AddTokenCommand, Response<string>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly AddTokenValidator _validationRules;
        private readonly ILogger<AddTokenHandler> _logger;
        private readonly INotify _nofity;

        public AddTokenHandler(IUsuarioRepository usuarioRepository, IMapper mapper, IConfiguration configuration, AddTokenValidator validationRules, ILogger<AddTokenHandler> logger/*, INotify nofity*/)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _configuration = configuration;
            _validationRules = validationRules;
            _logger = logger;
            /*_nofity = nofity;*/
        }

        public async Task<Response<string>> Handle(AddTokenCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<string>();
            try
            {
                var validationResult = _validationRules.Validate(request);

                if (!validationResult.IsValid)
                {
                    response.Message = "Errores de Validación";
                    response.Errors = validationResult.Errors;
                    _logger.LogInformation(response.Message);
                    //await _nofity.Publish(response.Message);
                    return response;
                }

                var account = await _usuarioRepository.GetAsync(request.UserName, request.Password);
                if (account is not null)
                {
                    /*if (BC.Verify(request.Password, account.Password))
                    {**/
                        response.Data = GenerateToken(account);
                        response.IsSuccess = true;
                        response.Message = "Token Exitoso!!!";
                        _logger.LogInformation(response.Message);
                        //await _nofity.Publish(response.Message);
                        return response;
                    /*}*/
                }
                else
                {
                    response.Message = "Cuenta No Valida!!!";
                    _logger.LogInformation(response.Message);
                    //await _nofity.Publish(response.Message);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex, response.Message);
            }

            return response;
        }

        private string GenerateToken(Usuario account)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, account.UserName),
                new Claim(JwtRegisteredClaimNames.FamilyName, account.UserName),
                new Claim(JwtRegisteredClaimNames.GivenName, account.UserName),
                new Claim(JwtRegisteredClaimNames.UniqueName, account.IdUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, Guid.NewGuid().ToString(), ClaimValueTypes.Integer64),
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:Expires"])),
                notBefore: DateTime.UtcNow,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
