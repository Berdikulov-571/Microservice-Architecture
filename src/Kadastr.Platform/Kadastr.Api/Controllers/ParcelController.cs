using Kadastr.Service.UseCases.Parcels.Commands.Create;
using Kadastr.Service.UseCases.Parcels.Commands.Delete;
using Kadastr.Service.UseCases.Parcels.Commands.Update;
using Kadastr.Service.UseCases.Parcels.Handlers.Create;
using Kadastr.Service.UseCases.Parcels.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kadastr.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ParcelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ParcelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(ParcelCreateCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int parcelId)
        {
            var result = await _mediator.Send(new GetParcelByIdQuery() { ParcelId = parcelId });

            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int parcellId)
        {
            var result = await _mediator.Send(new ParcelDeleteCommand() { ParcelId = parcellId });

            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(ParcelUpdateCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var result = await _mediator.Send(new GetAllParcelsQuery());

            return Ok(result);
        }
    }
}