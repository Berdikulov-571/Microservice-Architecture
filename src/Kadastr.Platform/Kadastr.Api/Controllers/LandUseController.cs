using Kadastr.Service.UseCases.LandUses.Commands.Create;
using Kadastr.Service.UseCases.LandUses.Commands.Delete;
using Kadastr.Service.UseCases.LandUses.Commands.Update;
using Kadastr.Service.UseCases.LandUses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kadastr.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LandUseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LandUseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(CreateLandUseCommand command)
        {
            int result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int landUseId)
        {
            var landUse = await _mediator.Send(new GetLandUseByIdQuery() { LandUseId = landUseId });

            return Ok(landUse);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int landUseId)
        {
            var result = await _mediator.Send(new DeleteLandUseCommand() { LandUseId=landUseId });

            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(UpdateLandUseCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var result = await _mediator.Send(new GetAllLandUseQuery());

            return Ok(result);
        }
    }
}