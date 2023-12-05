using MediatR;

namespace School.Service.Abstractions.UseCases.Tasks.Queries.Get
{
    public class GetAllTaskQuery : IRequest<IEnumerable<School.Domain.Entities.Task.Tasks>>
    {

    }
}