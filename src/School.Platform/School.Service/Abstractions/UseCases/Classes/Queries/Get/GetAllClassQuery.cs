using MediatR;
using School.Domain.Entities.Classes;

namespace School.Service.Abstractions.UseCases.Classes.Queries.Get
{
    public class GetAllClassQuery : IRequest<IEnumerable<Class>>
    {

    }
}