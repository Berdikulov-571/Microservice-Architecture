using MediatR;
using PublicTransport.Domain.Entities.Schedules;

namespace PublicTransport.Service.UseCases.Schedules.Queries
{
    public class GetScheduleByIdQuery : IRequest<Schedule>
    {
        public int ScheduleId { get;set; }
    }
}