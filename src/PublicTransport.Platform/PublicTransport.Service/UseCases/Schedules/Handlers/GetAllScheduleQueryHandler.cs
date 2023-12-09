using MediatR;
using Microsoft.EntityFrameworkCore;
using PublicTransport.Domain.Entities.Schedules;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Schedules.Queries;

namespace PublicTransport.Service.UseCases.Schedules.Handlers
{
    public class GetAllScheduleQueryHandler : IRequestHandler<GetAllScheduleQuery, IEnumerable<Schedule>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllScheduleQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Schedule>> Handle(GetAllScheduleQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Schedules.ToListAsync(cancellationToken);

            return result;
        }
    }
}