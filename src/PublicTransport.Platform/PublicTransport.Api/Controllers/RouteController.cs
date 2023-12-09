using MediatR;
using Microsoft.AspNetCore.Mvc;
using PublicTransport.Service.UseCases.Routes.Commands;
using PublicTransport.Service.UseCases.Routes.Queries;

namespace PublicTransport.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RouteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RouteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] CreateRouteCommand route)
        {
            return Ok(await _mediator.Send(route));
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int routeId)
        {
            return Ok(await _mediator.Send(new GetRouteByIdQuery() { RouteId = routeId }));
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int routeId)
        {
            return Ok(await _mediator.Send(new DeleteRouteCommand() { RouteId = routeId }));
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync([FromForm] UpdateRouteCommand route)
        {
            return Ok(await _mediator.Send(route));
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            return Ok(await _mediator.Send(new GetAllRouteQuery()));
        }
    }
}