using MediatR;
using PublicTransport.Domain.Dtos.Schedules;

namespace PublicTransport.Service.UseCases.Schedules.Commands
{
    public class CreateScheduleCommand : ScheduleCreateDto, IRequest<int>
    {

    }
}