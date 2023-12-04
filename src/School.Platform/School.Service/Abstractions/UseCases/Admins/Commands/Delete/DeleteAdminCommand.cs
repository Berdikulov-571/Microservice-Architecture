using MediatR;

namespace School.Service.Abstractions.UseCases.Admins.Commands.Delete
{
    public class DeleteAdminCommand : IRequest<int>
    {
        public int AdminId { get; set; }
    }
}
