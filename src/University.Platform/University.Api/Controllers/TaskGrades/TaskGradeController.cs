using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Domain.Entities.Task_Grades;
using University.Service.UseCases.Task_Grades.Commands.Create;
using University.Service.UseCases.Task_Grades.Commands.Delete;
using University.Service.UseCases.Task_Grades.Commands.Update;
using University.Service.UseCases.Task_Grades.Queries.Get;

namespace University.Api.Controllers.TaskGrades
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TaskGradeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskGradeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(CreateTaskGradeCommand taskGrade)
        {
            int result = await _mediator.Send(taskGrade);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int taskGradeId)
        {
            TaskGrade taskGrade = await _mediator.Send(new GetTaskGradeByIdQuery() { TaskGradeId = taskGradeId });

            return Ok(taskGrade);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int taskGradeId)
        {
            int result = await _mediator.Send(new DeleteTaskGradeCommand() { TaskGradeId = taskGradeId });

            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(UpdateTaskGradeCommand taskGradeCommand)
        {
            int result = await _mediator.Send(taskGradeCommand);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            IEnumerable<TaskGrade> taskGrades = await _mediator.Send(new GetAllTaskGradeQuery());

            return Ok(taskGrades);
        }
    }
}