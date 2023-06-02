using BrowserTravelAplication.Features.Editorial.Commands.PostEditorial;
using BrowserTravelAplication.Features.Editorial.Commands.PutEditorial;
using BrowserTravelAplication.Features.Editorial.Queries.GetEditorial;
using BrowserTravelAplication.Models;
using BrowserTravelDomain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BrowserTravelCoreApi.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class EditorialController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EditorialController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetEditorial")]
        public async Task<ActionResult<IEnumerable<EditorialVm>>> GetEditorial(int? Id)
        {
            var query = await _mediator.Send(new GetEditorialQuery(Id));
            return Ok(query);
        }
        [HttpPost("AddEditorial")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateEditorial([FromBody] PostEditorialCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("UpEditorial")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> UpdateEditorial([FromBody] PutEditorialCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
