using MediatR;
using School.Domain.Entities.Classes;

namespace School.Service.UseCases.Classes.Queries.Get
{
    public class GetAllClassQuery : IRequest<IEnumerable<Class>>
    {

    }
}