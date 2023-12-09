using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using TelegramBot;
using University.Domain.Dtos.Subjects;
using University.Domain.Entities.Subjects;
using University.Service.UseCases.Subjects.Commands.Create;
using University.Service.UseCases.Subjects.Commands.Delete;
using University.Service.UseCases.Subjects.Commands.Update;
using University.Service.UseCases.Subjects.Queries.Get;

namespace University.Api.Controllers.Subjects
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
        public async ValueTask<IActionResult> CreateAsync(CreateSubjectCommand subject)
        {
            int result = await _mediator.Send(subject);



            return Ok(subject);
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

   
            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(UpdateSubjectCommand subject)
        {
            int result = await _mediator.Send(subject);


            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            IEnumerable<Subject> subjects = await _mediator.Send(new GetAllSubjectQuery());

            return Ok(subjects);
        }
    }
}