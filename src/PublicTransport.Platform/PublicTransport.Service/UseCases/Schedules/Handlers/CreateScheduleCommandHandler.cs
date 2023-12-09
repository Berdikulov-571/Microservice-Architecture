using MediatR;
using PublicTransport.Domain.Entities.Schedules;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Schedules.Commands;

namespace PublicTransport.Service.UseCases.Schedules.Handlers
{
    public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateScheduleCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            Schedule schedule = new Schedule()
            {
                RouteId = request.RouteId,
                TransportId = request.TransportId,
                DepartureTime = DateTime.Now
            };

            await _context.Schedules.AddAsync(schedule, cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}