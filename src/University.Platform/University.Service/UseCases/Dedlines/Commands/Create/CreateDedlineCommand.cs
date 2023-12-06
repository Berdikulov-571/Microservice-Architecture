using MediatR;
using University.Domain.Dtos.Dedlines;

namespace University.Service.UseCases.Dedlines.Commands.Create
{
    public class CreateDedlineCommand : DedlineCreateDto, IRequest<int>
    {

    }
}