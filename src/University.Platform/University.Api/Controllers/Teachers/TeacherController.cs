using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TelegramBot;
using University.Domain.Entities.Teachers;
using University.Service.UseCases.Teachers.Commands.Create;
using University.Service.UseCases.Teachers.Commands.Delete;
using University.Service.UseCases.Teachers.Commands.Update;
using University.Service.UseCases.Teachers.Queries.Get;

namespace University.Api.Controllers.Teachers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TeacherController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeacherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] CreateTeacherCommand teacher)
        {
            int result = await _mediator.Send(teacher);


            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int teacherId)
        {
            Teacher teacher = await _mediator.Send(new GetTeacherByIdQuery() { TeacherId = teacherId });

            return Ok(teacher);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int teacherId)
        {
            int result = await _mediator.Send(new DeleteTeacherCommand() { TeacherId = teacherId });


            return Ok(result);
        }

        [Authorize(Roles = "Teacher")]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            IEnumerable<Teacher> teachers = await _mediator.Send(new GetAllTeacherQuery());

            return Ok(teachers);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync([FromForm] UpdateTeacherCommand teacher)
        {
            int result = await _mediator.Send(teacher);


            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<FileResult> GetImage(int teacherId)
        {
            byte[] image = await _mediator.Send(new GetTeacherImage() { TeacherId = teacherId });

            return File(image, "image/png");
        }
    }
}