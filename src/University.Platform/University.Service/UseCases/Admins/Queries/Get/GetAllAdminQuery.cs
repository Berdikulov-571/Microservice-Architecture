using MediatR;
using University.Domain.Entities.Admins;

namespace University.Service.UseCases.Admins.Queries.Get
{
    public class GetAllAdminQuery : IRequest<IEnumerable<Admin>>
    {

    }
}