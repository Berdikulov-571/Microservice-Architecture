using Kadastr.Service.UseCases.Owners.Commands.Create;
using Kadastr.Service.UseCases.Owners.Commands.Delete;
using Kadastr.Service.UseCases.Owners.Commands.Update;
using Kadastr.Service.UseCases.Owners.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Kadastr.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OwnerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OwnerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(CreateOwnerCommand command)
        {
            int result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdASync(int ownerId)
        {
            var result = await _mediator.Send(new GetOwnerByIdQuery() { OwnerId = ownerId });

            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int ownerId)
        {
            var result = await _mediator.Send(new DeleteOwnerCommand() { OwnerId = ownerId });

            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(UpdateOwnerCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var result = await _mediator.Send(new GetAllOwnerQuery());

            return Ok(result);
        }
    }
}