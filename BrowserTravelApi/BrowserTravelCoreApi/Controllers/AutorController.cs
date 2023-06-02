using BrowserTravelAplication.Features.Autores.Commands.PostAutor;
using BrowserTravelAplication.Features.Autores.Commands.PutAutor;
using BrowserTravelAplication.Features.Autores.Queries.GetAutor;
using BrowserTravelAplication.Features.Editorial.Commands.PostEditorial;
using BrowserTravelAplication.Features.Editorial.Commands.PutEditorial;
using BrowserTravelAplication.Features.Editorial.Queries.GetEditorial;
using BrowserTravelAplication.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BrowserTravelCoreApi.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AutorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetAutor")]
        public async Task<ActionResult<IEnumerable<AutorVm>>> GetAutor(int? Id)
        {
            var query = await _mediator.Send(new GetAutorQuery(Id));
            return Ok(query);
        }
        [HttpPost("AddAutor")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateAutor([FromBody] PostAutorCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("UpAutor")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> UpdateAutor([FromBody] PutAutorCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
