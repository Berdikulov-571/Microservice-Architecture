using MediatR;
using Microsoft.AspNetCore.Mvc;
using PublicTransport.Service.UseCases.Drivers.Commands;
using PublicTransport.Service.UseCases.Drivers.Queries;

namespace PublicTransport.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DriverController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DriverController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm]CreateDriverCommand driver)
        {
            return Ok(await _mediator.Send(driver));
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int driverId)
        {
            var driver = await _mediator.Send(new GetDriverByIdQuery() { DriverId = driverId});

            return Ok(driver);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int driverId)
        {
            return Ok(await _mediator.Send(new DeleteDriverCommand() { DriverId = driverId}));
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync([FromForm] UpdateDriverCommand driver)
        {
            return Ok(await _mediator.Send(driver));
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            return Ok(await _mediator.Send(new GetAllDriverQuery()));
        }
    }
}
