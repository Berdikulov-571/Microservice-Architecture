using MediatR;
using Microsoft.AspNetCore.Mvc;
using PublicTransport.Service.UseCases.Users.Commands;
using PublicTransport.Service.UseCases.Users.Queries;

namespace PublicTransport.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] CreateUserCommand user)
        {
            return Ok(await _mediator.Send(user));
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int userId)
        {
            return Ok(await _mediator.Send(new GetUserByIdQuery() { UserId = userId}));
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int userId)
        {
            return Ok(await _mediator.Send(new DeleteUserCommand() { UserId = userId}));
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync([FromForm] UpdateUserCommand user)
        {
            return Ok(await _mediator.Send(user));
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            return Ok(await _mediator.Send(new GetAllUsersQuery()));
        }
    }
}