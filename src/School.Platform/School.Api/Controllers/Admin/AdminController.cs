using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Dtos.Admins;
using School.Service.Abstractions.UseCases.Admins.Commands.Create;

namespace School.Api.Controllers.Admin
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> PostAsync([FromForm]CreateAdminCommand admin)
        {
            int result = await _mediator.Send(admin);

            return Ok(result);
        }
    }
}
