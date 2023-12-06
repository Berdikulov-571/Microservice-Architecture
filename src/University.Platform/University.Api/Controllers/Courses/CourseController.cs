using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Domain.Entities.Courses;
using University.Service.UseCases.Courses.Commands.Create;
using University.Service.UseCases.Courses.Commands.Delete;
using University.Service.UseCases.Courses.Commands.Update;
using University.Service.UseCases.Courses.Queries.Get;

namespace University.Api.Controllers.Courses
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(CreateCourseCommand course)
        {
            int result = await _mediator.Send(course);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int courseId)
        {
            Course course = await _mediator.Send(new GetCourseByIdQuery() { CourseId = courseId });

            return Ok(course);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int courseId)
        {
            int result = await _mediator.Send(new DeleteCourseCommand() { CourseId = courseId});

            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(UpdateCourseCommand course)
        {
            int result = await _mediator.Send(course);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            IEnumerable<Course> courses = await _mediator.Send(new GetAllCourseQuery());

            return Ok(courses);
        }
    }
}