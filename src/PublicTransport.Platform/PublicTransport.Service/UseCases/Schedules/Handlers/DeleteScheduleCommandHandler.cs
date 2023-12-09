using MediatR;
using Microsoft.EntityFrameworkCore;
using PublicTransport.Domain.Entities.Schedules;
using PublicTransport.Service.Abstractions.DataContexts;
using PublicTransport.Service.UseCases.Schedules.Commands;

namespace PublicTransport.Service.UseCases.Schedules.Handlers
{
    public class DeleteScheduleCommandHandler : IRequestHandler<DeleteScheduleCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteScheduleCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
        {
            Schedule schedule = await _context.Schedules.FirstOrDefaultAsync(x => x.Id == request.ScheduleId, cancellationToken);

            if (schedule == null)
            {
                return 0;
            }

            _context.Schedules.Remove(schedule);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}