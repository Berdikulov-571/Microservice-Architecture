using MediatR;
using University.Domain.Entities.Lessons;
using University.Domain.Entities.MissedLessons;

namespace University.Service.UseCases.MissedLessons.Queries.Get
{
    public class GetAllNbQuery : IRequest<IEnumerable<NB>>
    {

    }
}