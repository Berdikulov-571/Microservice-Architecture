using MediatR;
using School.Domain.Entities.Admins;

namespace School.Service.UseCases.Admins.Queries.Get
{
    public class GetAdminByIdQuery : IRequest<Admin>
    {
        public int AdminId { get; set; }
    }
}