using MediatR;
using Microsoft.AspNetCore.Mvc;
using PublicTransport.Service.UseCases.Schedules.Commands;
using PublicTransport.Service.UseCases.Schedules.Queries;

namespace PublicTransport.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SchedulesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SchedulesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] CreateScheduleCommand schedule)
        {
            return Ok(await _mediator.Send(schedule));
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int scheduleId)
        {
            return Ok(await _mediator.Send(new GetScheduleByIdQuery() { ScheduleId = scheduleId}));
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int scheduleId)
        {
            return Ok(await _mediator.Send(new DeleteScheduleCommand() { ScheduleId = scheduleId}));
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync([FromForm] UpdateScheduleCommand schedule)
        {
            return Ok(await _mediator.Send(schedule));
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            return Ok(await _mediator.Send(new GetAllScheduleQuery()));
        }
    }
}
