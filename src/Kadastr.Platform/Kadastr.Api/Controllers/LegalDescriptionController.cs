using Kadastr.Service.UseCases.LegalDescriptions.Commands.Create;
using Kadastr.Service.UseCases.LegalDescriptions.Commands.Delete;
using Kadastr.Service.UseCases.LegalDescriptions.Commands.Update;
using Kadastr.Service.UseCases.LegalDescriptions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace Kadastr.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LegalDescriptionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LegalDescriptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(CreateLegalDescriptionCommand comand)
        {
            int result = await _mediator.Send(comand);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int legalDescriptionId)
        {
            var result = await _mediator.Send(new GetLegalDescriptionByIdQuery() { LegalDescriptionId = legalDescriptionId });

            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int legalDescriptionId)
        {
            var result = await _mediator.Send(new DeleteLegalDescriptionCommand() { LegalDescriptionId = legalDescriptionId });

            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(UpdateLegalDescriptionCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var result = await _mediator.Send(new GetAllLegalDescriptionQuery());

            return Ok(result);
        }
    }
}