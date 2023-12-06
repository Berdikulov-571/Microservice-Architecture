using MediatR;
using University.Domain.Entities.Admins;

namespace University.Service.UseCases.Admins.Queries.Get
{
    public class GetAdminByIdQuery : IRequest<Admin>
    {
        public int AdminId { get; set; }
    }
}