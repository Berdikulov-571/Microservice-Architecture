using MediatR;
using School.Domain.Entities.Admins;

namespace School.Service.Abstractions.UseCases.Admins.Queries.Get
{
    public class GetAllAdminQuery : IRequest<IEnumerable<Admin>>
    {

    }
}