using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using PadelAPI.Commands;
using PadelAPI.Models;
using PadelAPI.Queries;

namespace PadelAPI.Controllers
{
    [ApiController]
    [Route("api/padelsession")]
    public class PadelSessionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PadelSessionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<PadelSession>> GetAllPadelSessions()
        {
            var query = new GetAllPadelSessionsQuery();
            return await _mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PadelSession>> GetPadelSessionById(Guid id)
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
        public async Task<IActionResult> UpdatePadelSession(Guid id, [FromBody] PadelSession updatedPadel)
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<PadelSession>> DeletePadelSession(Guid id)
        {
            var command = new DeletePadelSessionCommand(id);
            var deleteSession = await _mediator.Send(command);

            if (deleteSession == null)
            {
                return NotFound();
            }

            return Ok(deleteSession);
        }
    }

}
