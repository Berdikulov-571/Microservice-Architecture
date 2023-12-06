using MediatR;
using University.Domain.Entities.MissedLessons;

namespace University.Service.UseCases.MissedLessons.Queries.Get
{
    public class GetnbByIdQuery : IRequest<NB>
    {
        public int NbId { get; set; }
    }
}