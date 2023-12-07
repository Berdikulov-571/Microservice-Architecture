using Kadastr.Service.UseCases.Transactions.Commands.Create;
using Kadastr.Service.UseCases.Transactions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kadastr.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(CreateTransactionCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int transactionId)
        {
            var result = await _mediator.Send(new GetTransactionByIdQuery() { TransactionId = transactionId});

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllTransaction()
        {
            var result = await _mediator.Send(new GetAllTransactionQuery());

            return Ok(result);
        }

    }
}
