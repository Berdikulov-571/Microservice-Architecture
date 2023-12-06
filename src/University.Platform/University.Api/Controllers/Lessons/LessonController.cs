using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Domain.Entities.Lessons;
using University.Service.UseCases.Lessons.Commands.Create;
using University.Service.UseCases.Lessons.Commands.Delete;
using University.Service.UseCases.Lessons.Commands.Update;
using University.Service.UseCases.Lessons.Queries.Get;

namespace University.Api.Controllers.Lessons
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LessonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LessonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] CreateLessonCommand lesson)
        {
            int result = await _mediator.Send(lesson);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int lessonId)
        {
            Lesson result = await _mediator.Send(new GetLessonByIdQuery() { LessonId = lessonId });

            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int lessonId)
        {
            int result = await _mediator.Send(new DeleteLessonCommand() { LessonId = lessonId });

            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync([FromForm]UpdateLessonCommand lesson)
        {
            int result = await _mediator.Send(lesson);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            IEnumerable<Lesson> lessons = await _mediator.Send(new GetAllLessonsQuery());

            return Ok(lessons);
        }
    }
}