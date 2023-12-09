using MediatR;
using Microsoft.AspNetCore.Mvc;
using PublicTransport.Service.UseCases.Transports.Commands;
using PublicTransport.Service.UseCases.Transports.Queries;

namespace PublicTransport.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TransportController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] CreateTransportCommand transport)
        {
            return Ok(await _mediator.Send(transport));
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int transportId)
        {
            return Ok(await _mediator.Send(new GetTransportByIdQuery() { TransportId = transportId }));
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int transportId)
        {
            return Ok(await _mediator.Send(new DeleteTransportCommand() { TransportId = transportId}));
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync([FromForm] UpdateTransportCommand transport)
        {
            return Ok(await _mediator.Send(transport));
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            return Ok(await _mediator.Send(new GetAllTransportQuery()));
        }
    }
}
