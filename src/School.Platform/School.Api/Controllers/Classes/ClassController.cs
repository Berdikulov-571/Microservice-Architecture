using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Entities.Classes;
using School.Service.UseCases.Classes.Commands.Create;
using School.Service.UseCases.Classes.Commands.Delete;
using School.Service.UseCases.Classes.Commands.Update;
using School.Service.UseCases.Classes.Queries.Get;
using TelegramBot;

namespace School.Api.Controllers.Classes
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ClassController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClassController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> PostAsync([FromForm] CreateClassCommand @class)
        {
            int result = await _mediator.Send(@class);

            BotMessage bot = new BotMessage();
            await bot.Added("School.Api -> Class");

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int classId)
        {
            GetClassByIdQuery @class = new GetClassByIdQuery()
            {
                ClassId = classId
            };

            Class result = await _mediator.Send(@class);

            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int classId)
        {
            DeleteClassCommand @class = new DeleteClassCommand()
            {
                ClassId = classId
            };

            int result = await _mediator.Send(@class);

            BotMessage bot = new BotMessage();
            await bot.Deleted("School.Api -> Class");

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            IEnumerable<Class> classes = await _mediator.Send(new GetAllClassQuery());

            return Ok(classes);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync([FromForm]UpdateClassCommand @class)
        {
            int result = await _mediator.Send(@class);

            BotMessage bot = new BotMessage();
            await bot.Updated("School.Api -> Class");

            return Ok(result);
        }
    }
}