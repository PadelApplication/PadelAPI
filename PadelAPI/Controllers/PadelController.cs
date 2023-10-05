using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using PadelAPI.Commands;
using PadelAPI.Models;
using PadelAPI.Queries;

namespace PadelAPI.Controllers
{
    [ApiController]
    [Route("api/padel")]
    public class PadelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PadelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Padel>> GetAllPadelSessions()
        {
            var query = new GetAllPadelSessionsQuery();
            return await _mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Padel>> GetPadelSessionById(Guid id)
        {
            var query = new GetPadelSessionByIdQuery(id);
            var padelSession = await _mediator.Send(query);

            if (padelSession == null)
            {
                return NotFound();
            }

            return Ok(padelSession);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePadelSession([FromBody] CreatePadelSessionCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePadelSession(Guid id, [FromBody] Padel updatedPadel)
        {
            try
            {
                updatedPadel.Id = id;
                var command = new UpdatePadelSessionCommand { UpdatedPadel = updatedPadel };
                var result = await _mediator.Send(command);

                if (result)
                    return Ok("Padel session updated successfully");

                return NotFound("Padel session not found");
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }

}
