using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Entities.Teachers;
using School.Service.UseCases.ClassTasks.Commands.Create;
using School.Service.UseCases.ClassTasks.Commands.Delete;
using School.Service.UseCases.ClassTasks.Commands.Update;
using School.Service.UseCases.ClassTasks.Queries.Get;

namespace School.Api.Controllers.ClassTasks
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ClassTaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClassTaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> PostAsync([FromForm] CreateClassTaskCommand classTask)
        {
            int result = await _mediator.Send(classTask);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int teacherId)
        {
            var result = await _mediator.Send(new GetClassTaskByIdQuery() { TeacherId = teacherId });

            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int classTaskId)
        {
            int result = await _mediator.Send(new DeleteClassTaskCommand() { ClassTaskId = classTaskId });

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            IEnumerable<Teacher> result = await _mediator.Send(new GetAllClassTasksQuery());

            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(UpdateClassTaskCommand command)
        {
            int result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}