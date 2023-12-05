using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Service.UseCases.Tasks.Commands.Create;
using School.Service.UseCases.Tasks.Commands.Delete;
using School.Service.UseCases.Tasks.Commands.Update;
using School.Service.UseCases.Tasks.Queries.Get;

namespace School.Api.Controllers.Tasks
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> PostAsync(CreateTaskCommand task)
        {
            int result = await _mediator.Send(task);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int taskId)
        {
            School.Domain.Entities.Task.Tasks result = await _mediator.Send(new GetTaskByIdQuery() { TaskId = taskId });

            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int taskId)
        {
            int result = await _mediator.Send(new DeleteTaskCommand() { TaskId = taskId });

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            IEnumerable<School.Domain.Entities.Task.Tasks> tasks = await _mediator.Send(new GetAllTaskQuery());

            return Ok(tasks);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(UpdateTaskCommand task)
        {
            int result = await _mediator.Send(task);

            return Ok(result);
        }
    }
}