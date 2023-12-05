using MediatR;

namespace School.Service.UseCases.Admins.Commands.Delete
{
    public class DeleteAdminCommand : IRequest<int>
    {
        public int AdminId { get; set; }
    }
}
