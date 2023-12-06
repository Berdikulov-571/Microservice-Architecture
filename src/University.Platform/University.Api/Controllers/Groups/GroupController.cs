using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Domain.Entities.Groups;
using University.Service.UseCases.Groups.Commands.Create;
using University.Service.UseCases.Groups.Commands.Delete;
using University.Service.UseCases.Groups.Commands.Update;
using University.Service.UseCases.Groups.Queries.Get;

namespace University.Api.Controllers.Groups
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GroupController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GroupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(CreateGroupCommand group)
        {
            int result = await _mediator.Send(group);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int groupId)
        {
            Group group = await _mediator.Send(new GetGroupByIdQuery() { GroupId = groupId });

            return Ok(group);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int groupId)
        {
            int result = await _mediator.Send(new DeleteGroupCommand() { GroupId = groupId });

            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(UpdateGroupCommand group)
        {
            int result = await _mediator.Send(group);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            IEnumerable<Group> groups = await _mediator.Send(new GetAllGroupQuery());

            return Ok(groups);
        }
    }
}