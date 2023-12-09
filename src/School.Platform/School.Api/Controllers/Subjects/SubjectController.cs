using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Entities.Subjects;
using School.Service.UseCases.Students.Commands.Delete;
using School.Service.UseCases.Subjects.Commands.Create;
using School.Service.UseCases.Subjects.Commands.Delete;
using School.Service.UseCases.Subjects.Commands.Update;
using School.Service.UseCases.Subjects.Queries.Get;
using TelegramBot;

namespace School.Api.Controllers.Subjects
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SubjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] CreateSubjectCommand subject)
        {
            int result = await _mediator.Send(subject);

            BotMessage bot = new BotMessage();
            await bot.Added("School.Api -> Subject");

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int subjectId)
        {
            Subject subject = await _mediator.Send(new GetSubjectByIdQuery() { SubjectId = subjectId});

            return Ok(subject);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int subjectId)
        {
            int result = await _mediator.Send(new DeleteSubjectCommand() { SubjectId = subjectId});

            BotMessage bot = new BotMessage();
            await bot.Deleted("School.Api -> Subject");

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            IEnumerable<Subject> subjects = await _mediator.Send(new GetAllSubjecttQuery());

            return Ok(subjects);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync([FromForm] UpdateSubjectCommand subject)
        {
            int result = await _mediator.Send(subject);

            BotMessage bot = new BotMessage();
            await bot.Updated("School.Api -> Subject");

            return Ok(result);
        }
    }
}