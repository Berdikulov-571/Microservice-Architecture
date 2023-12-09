using MediatR;

namespace PublicTransport.Service.UseCases.Schedules.Commands
{
    public class DeleteScheduleCommand : IRequest<int>
    {
        public int ScheduleId { get; set; }
    }
}