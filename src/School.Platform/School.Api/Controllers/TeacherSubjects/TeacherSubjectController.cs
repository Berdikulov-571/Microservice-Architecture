using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Entities.Subjects;
using School.Service.UseCases.TeacherSubjectRelation.Commands.Create;
using School.Service.UseCases.TeacherSubjectRelation.Commands.Delete;
using School.Service.UseCases.TeacherSubjectRelation.Commands.Update;
using School.Service.UseCases.TeacherSubjectRelation.Queries.Get;

namespace School.Api.Controllers.TeacherSubjects
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TeacherSubjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeacherSubjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(CreateTeacherSubjectCommand command)
        {
            int result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int teacherId)
        {
            IEnumerable<Subject> subjects = await _mediator.Send(new GetTeacherSubjectByTeacherIdQuery() { TeacherId = teacherId});

            return Ok(subjects);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int teacherSubjectId)
        {
            int result = await _mediator.Send(new DeleteTeacherSubjectCommand() { TeacherSubjectId = teacherSubjectId});

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            IEnumerable<Subject> result = await _mediator.Send(new GetAllTeacherSubjectQuery());

            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(UpdateTeacherSubjectCommand command)
        {
            int result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}