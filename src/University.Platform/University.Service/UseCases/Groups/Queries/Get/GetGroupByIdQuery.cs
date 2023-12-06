using MediatR;
using University.Domain.Entities.Groups;

namespace University.Service.UseCases.Groups.Queries.Get
{
    public class GetGroupByIdQuery : IRequest<Group>
    {
        public int GroupId { get; set; }
    }
}