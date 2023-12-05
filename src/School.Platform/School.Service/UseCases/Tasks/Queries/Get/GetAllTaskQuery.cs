using MediatR;

namespace School.Service.UseCases.Tasks.Queries.Get
{
    public class GetAllTaskQuery : IRequest<IEnumerable<Domain.Entities.Task.Tasks>>
    {

    }
}