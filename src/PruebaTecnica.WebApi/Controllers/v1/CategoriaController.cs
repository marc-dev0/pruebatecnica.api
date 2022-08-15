using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Application.Commons;
using PruebaTecnica.Application.Services.Categoria.Commands.InsUpdCategoriaCommand;
using PruebaTecnica.Application.Services.Categoria.Queries;
using System.Threading.Tasks;

namespace PruebaTecnica.WebApi.Controllers.v1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriaController : Controller
    {
        private readonly IMediator _mediator;

        public CategoriaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCategoriaAllFilterAsync")]
        public async Task<IActionResult> GetCategoriaAllFilterAsync([FromQuery] GetCategoriaAllFilterQuery query)
        {
            var response = await _mediator.Send(query);
            return response.IsSuccess ? Ok(response) : BadRequest(response);

            //if (response.IsSuccess)
            //    return Ok(response);
            //else
            //    return BadRequest(response);
        }

        [HttpPost("InsertUpdateAsync")]
        public async Task<IActionResult> InsertUpdateAsync([FromBody] InsUpdCategoriaCommand insUpdCategoriaCommand)
        {
            if (insUpdCategoriaCommand is null)
                return BadRequest();

            var response = await _mediator.Send(insUpdCategoriaCommand);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
