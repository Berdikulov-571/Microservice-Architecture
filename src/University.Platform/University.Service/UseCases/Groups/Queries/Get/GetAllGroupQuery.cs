using MediatR;
using University.Domain.Entities.Groups;

namespace University.Service.UseCases.Groups.Queries.Get
{
    public class GetAllGroupQuery : IRequest<IEnumerable<Group>>
    {
    }
}