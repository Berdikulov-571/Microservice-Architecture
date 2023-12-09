using MediatR;
using PublicTransport.Domain.Dtos.Schedules;

namespace PublicTransport.Service.UseCases.Schedules.Commands
{
    public class UpdateScheduleCommand : ScheduleUpdateDto, IRequest<int>
    {

    }
}