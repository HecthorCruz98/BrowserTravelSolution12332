using BrowserTravelAplication.Features.Editorial.Commands.PostEditorial;
using BrowserTravelAplication.Features.Editorial.Commands.PutEditorial;
using BrowserTravelAplication.Features.Editorial.Queries.GetEditorial;
using BrowserTravelAplication.Features.Libro.Commands.PostLibro;
using BrowserTravelAplication.Features.Libro.Commands.PutLibro;
using BrowserTravelAplication.Features.Libro.Queries.GetLibro;
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
    public class LibroController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LibroController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetLibro")]
        public async Task<ActionResult<IEnumerable<LibroVm>>> GetLibro(int? Id)
        {
            var query = await _mediator.Send(new GetLibroQuery(Id));
            return Ok(query);
        }
        [HttpPost("AddLibro")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateLibro([FromBody] PostLibroCommad command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("UpLibro")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> UpdateLibro([FromBody] PutLibroCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
