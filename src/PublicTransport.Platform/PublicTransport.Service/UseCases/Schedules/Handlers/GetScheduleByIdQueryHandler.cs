using MediatR;
using Microsoft.EntityFrameworkCore;
using PublicTransport.Domain.Entities.Schedules;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Schedules.Queries;

namespace PublicTransport.Service.UseCases.Schedules.Handlers
{
    public class GetScheduleByIdQueryHandler : IRequestHandler<GetScheduleByIdQuery, Schedule>
    {
        private readonly IApplicationDbContext _context;

        public GetScheduleByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Schedule> Handle(GetScheduleByIdQuery request, CancellationToken cancellationToken)
        {
            var schedule = await _context.Schedules.FirstOrDefaultAsync(x => x.Id == request.ScheduleId, cancellationToken);

            return schedule;
        }
    }
}