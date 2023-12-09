using MediatR;
using Microsoft.AspNetCore.Mvc;
using PublicTransport.Service.UseCases.Payments.Commands;
using PublicTransport.Service.UseCases.Payments.Queries;

namespace PublicTransport.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] CreatePaymentCommand payment)
        {
            return Ok(await _mediator.Send(payment));
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int paymentId)
        {
            return Ok(await _mediator.Send(new GetPaymentByIdQuery() { PaymentId = paymentId }));
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int paymentId)
        {
            return Ok(await _mediator.Send(new DeletePaymentCommand() { PaymentId = paymentId }));
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            return Ok(await _mediator.Send(new GetAllPaymentQuery()));
        }
    }
}
