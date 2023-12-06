using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Domain.Entities.Dedlines;
using University.Service.UseCases.Dedlines.Commands.Create;
using University.Service.UseCases.Dedlines.Commands.Delete;
using University.Service.UseCases.Dedlines.Commands.Update;
using University.Service.UseCases.Dedlines.Queries.Get;

namespace University.Api.Controllers.Dedlines
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DedlineController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DedlineController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm]CreateDedlineCommand dedline)
        {
            int result = await _mediator.Send(dedline);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetDedlineByIdAsync(int dedlineId)
        {
            Dedline dedline = await _mediator.Send(new GetDedlineByIdQuery() { DedlineId = dedlineId });

            return Ok(dedline);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int deleteId)
        {
            int result = await _mediator.Send(new DeleteDedlineCommand() { DedlineId = deleteId });

            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync([FromForm]UpdateDedlineCommand dedline)
        {
            int result = await _mediator.Send(dedline);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            IEnumerable<Dedline> dedlines = await _mediator.Send(new GetAllDedlineQuery());

            return Ok(dedlines);
        }
    }
}