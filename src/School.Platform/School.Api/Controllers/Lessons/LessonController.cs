using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Entities.Lessons;
using School.Service.UseCases.Lessons.Commands.Create;
using School.Service.UseCases.Lessons.Commands.Delete;
using School.Service.UseCases.Lessons.Commands.Update;
using School.Service.UseCases.Lessons.Queries.Get;
using TelegramBot;

namespace School.Api.Controllers.Lessons
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
        public async ValueTask<IActionResult> PostAsync([FromForm]CreateLessonCommand lesson)
        {
            int result = await _mediator.Send(lesson);

            BotMessage bot = new BotMessage();
            await bot.Added("School.Api -> Lesson");

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int lessonId)
        {
            Lesson lesson = await _mediator.Send(new GetLessonByIdQuery() { LessonId = lessonId });

            return Ok(lesson);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int lessonId)
        {
            int result = await _mediator.Send(new DeleteLessonCommand() { LessonId = lessonId });

            BotMessage bot = new BotMessage();
            await bot.Deleted("School.Api -> Lesson");

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            IEnumerable<Lesson> lessons = await _mediator.Send(new GetAllLessonQuery());

            return Ok(lessons);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync([FromForm]UpdateLessonCommand lesson)
        {
            int result = await _mediator.Send(lesson);

            BotMessage bot = new BotMessage();
            await bot.Updated("School.Api -> Lesson");

            return Ok(result);
        }
    }
}