using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Entities.Admins;
using School.Service.Abstractions.UseCases.Admins.Commands.Create;
using School.Service.Abstractions.UseCases.Admins.Commands.Delete;
using School.Service.Abstractions.UseCases.Admins.Commands.Update;
using School.Service.Abstractions.UseCases.Admins.Queries.Get;

namespace School.Api.Controllers.Admins
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
        public async ValueTask<IActionResult> PostAsync([FromForm] CreateAdminCommand admin)
        {
            int result = await _mediator.Send(admin);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int adminId)
        {
            GetAdminByIdQuery command = new GetAdminByIdQuery()
            {
                AdminId = adminId
            };

            Admin admin = await _mediator.Send(command);

            return Ok(admin);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int adminId)
        {
            DeleteAdminCommand command = new DeleteAdminCommand()
            {
                AdminId = adminId
            };

            int result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            IEnumerable<Admin> admins = await _mediator.Send(new GetAllAdminQuery());

            return Ok(admins);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync([FromForm] UpdateAdminCommand admin)
        {
            int result = await _mediator.Send(admin);

            return Ok(result);
        }
    }
}