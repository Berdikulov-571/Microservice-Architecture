using MediatR;
using University.Domain.Entities.Dedlines;

namespace University.Service.UseCases.Dedlines.Queries.Get
{
    public class GetDedlineByIdQuery : IRequest<Dedline>
    {
        public int DedlineId { get; set; }
    }
}