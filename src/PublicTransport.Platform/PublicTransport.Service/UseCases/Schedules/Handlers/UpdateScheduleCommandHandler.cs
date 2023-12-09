using MediatR;
using Microsoft.EntityFrameworkCore;
using PublicTransport.Domain.Entities.Schedules;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Schedules.Commands;

namespace PublicTransport.Service.UseCases.Schedules.Handlers
{
    public class UpdateScheduleCommandHandler : IRequestHandler<UpdateScheduleCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateScheduleCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateScheduleCommand request, CancellationToken cancellationToken)
        {
            Schedule schedule = await _context.Schedules.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (schedule == null)
            {
                return 0;
            }
            schedule.RouteId = request.RouteId;
            schedule.TransportId = request.TransportId;
            schedule.DepartureTime = DateTime.Now;

            _context.Schedules.Remove(schedule);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}