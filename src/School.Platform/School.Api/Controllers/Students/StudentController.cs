using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Entities.Students;
using School.Service.UseCases.Students.Commands.Create;
using School.Service.UseCases.Students.Commands.Delete;
using School.Service.UseCases.Students.Commands.Update;
using School.Service.UseCases.Students.Queries.Get;

namespace School.Api.Controllers.Students
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> PostAsync([FromForm] CreateStudentCommand student)
        {
            int result = await _mediator.Send(student);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int studentId)
        {
            Student student = await _mediator.Send(new GetStudentByIdQuery() { StudentId = studentId});

            return Ok(student);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int studentId)
        {
            int result = await _mediator.Send(new DeleteStudentCommand() { StudentId = studentId});

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            IEnumerable<Student> students = await _mediator.Send(new GetAllStudentQuery());

            return Ok(students);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync([FromForm]UpdateStudentCommand student)
        {
            int result = await _mediator.Send(student);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<FileContentResult> GetImageAsync(int studentId)
        {
            byte[] image = await _mediator.Send(new GetStudentImageQuery() { StudentId = studentId });

            return File(image, "image/png");
        }
    }
}