using Kadastr.Service.UseCases.PercalLandUse.Commands.Create;
using Kadastr.Service.UseCases.PercalLandUse.Commands.Delete;
using Kadastr.Service.UseCases.PercalLandUse.Commands.Update;
using Kadastr.Service.UseCases.PercalLandUses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kadastr.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ParcelLandUseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ParcelLandUseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(CreatePercalLanUseCommand command)
        {
            int result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int percelLandUseId)
        {
            var result = await _mediator.Send(new GetPercelLanUseByIdQuery() { PercelLanUseId = percelLandUseId});

            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int percelLandUseId)
        {
            var result = await _mediator.Send(new DeletePercalLanUseCommand() { PercalLanUse = percelLandUseId});

            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(UpdatePercalLanUseCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var result = await _mediator.Send(new GetAllPercalLanUseQuery());

            return Ok(result);
        }
    }
}