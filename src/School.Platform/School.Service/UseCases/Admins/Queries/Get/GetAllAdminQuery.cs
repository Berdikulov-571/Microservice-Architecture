using MediatR;
using School.Domain.Entities.Admins;

namespace School.Service.UseCases.Admins.Queries.Get
{
    public class GetAllAdminQuery : IRequest<IEnumerable<Admin>>
    {

    }
}