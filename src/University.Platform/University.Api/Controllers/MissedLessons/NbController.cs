using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Domain.Entities.MissedLessons;
using University.Service.UseCases.MissedLessons.Commands.Create;
using University.Service.UseCases.MissedLessons.Commands.Delete;
using University.Service.UseCases.MissedLessons.Commands.Update;
using University.Service.UseCases.MissedLessons.Queries.Get;

namespace University.Api.Controllers.MissedLessons
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class NbController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NbController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm]CreateNbCommand nb)
        {
            int result = await _mediator.Send(nb);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int nbId)
        {
            NB nb = await _mediator.Send(new GetnbByIdQuery() { NbId = nbId });

            return Ok(nb);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int nbId)
        {
            int result = await _mediator.Send(new DeleteNbCommand() { NbId = nbId });

            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync([FromForm]UpdateNbCommand nb)
        {
            int result = await _mediator.Send(nb);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllNbCommandHandler()
        {
            IEnumerable<NB> nbs = await _mediator.Send(new GetAllNbQuery());

            return Ok(nbs);
        }
    }
}