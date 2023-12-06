using MediatR;
using University.Domain.Dtos.Dedlines;

namespace University.Service.UseCases.Dedlines.Commands.Update
{
    public class UpdateDedlineCommand : DedlineUpdateDto, IRequest<int>
    {

    }
}