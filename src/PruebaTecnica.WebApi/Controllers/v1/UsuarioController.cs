using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Application.Commons;
using PruebaTecnica.Application.Services.Usuarios.Commands.AddTokenCommand;
using PruebaTecnica.Application.Services.Usuarios.Commands.AddUsuarioCommand;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnica.WebApi.Controllers.v1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Operación que permite crear una nueva Cuenta.
        /// </summary>
        /// <param name="AddUsuarioCommand">AddUsuarioCommand</param>
        /// <returns></returns>
        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] AddUsuarioCommand addUsuarioCommand)
        {
            if (addUsuarioCommand is null)
                return BadRequest();

            var response = await _mediator.Send(addUsuarioCommand);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response);
        }

        /// <summary>
        /// Operación que permite generar un TOKEN a partir de un client y secret.
        /// </summary>
        /// <param name="addTokenCommand">addTokenCommand</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
        [AllowAnonymous]
        [HttpPost("TokenAsync")]
        public async Task<IActionResult> TokenAsync([FromBody] AddTokenCommand addTokenCommand)
        {
            if (addTokenCommand is null)
                return BadRequest();

            var response = await _mediator.Send(addTokenCommand);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
