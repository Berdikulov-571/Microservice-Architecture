using MediatR;

namespace School.Service.UseCases.Admins.Queries.Get
{
    public class GetAdminImageQuery : IRequest<byte[]>
    {
        public int AdminId { get; set; }
    }
}