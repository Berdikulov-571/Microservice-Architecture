using MediatR;
using PublicTransport.Domain.Entities.Schedules;

namespace PublicTransport.Service.UseCases.Schedules.Queries
{
    public class GetAllScheduleQuery : IRequest<IEnumerable<Schedule>>
    {

    }
}