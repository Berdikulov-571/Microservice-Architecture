using MediatR;
using Microsoft.AspNetCore.Mvc;
using TelegramBot;
using University.Domain.Entities.Students;
using University.Service.UseCases.Students.Commands.Create;
using University.Service.UseCases.Students.Commands.Delete;
using University.Service.UseCases.Students.Commands.Update;
using University.Service.UseCases.Students.Queries.Get;

namespace University.Api.Controllers.Students
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

            BotMessage bot = new BotMessage();
            await bot.Added("University.Api -> Student");

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int studentId)
        {
            Student student = await _mediator.Send(new GetStudentByIdQuery() { StudentId = studentId });

            return Ok(student);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int studentId)
        {
            int result = await _mediator.Send(new DeleteStudentCommand() { StudentId = studentId });

            BotMessage bot = new BotMessage();
            await bot.Deleted("University.Api -> Student");

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            IEnumerable<Student> students = await _mediator.Send(new GetAllStudentQuery());

            return Ok(students);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync([FromForm] UpdateStudentCommand student)
        {
            int result = await _mediator.Send(student);

            BotMessage bot = new BotMessage();
            await bot.Updated("University.Api -> Student");

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