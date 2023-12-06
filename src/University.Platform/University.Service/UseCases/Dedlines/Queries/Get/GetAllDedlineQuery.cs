using MediatR;
using University.Domain.Entities.Dedlines;

namespace University.Service.UseCases.Dedlines.Queries.Get
{
    public class GetAllDedlineQuery : IRequest<IEnumerable<Dedline>>
    {

    }
}