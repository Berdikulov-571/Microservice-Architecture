using MediatR;

namespace Kadastr.Service.UseCases.Owners.Commands.Delete
{
    public class DeleteOwnerCommand : IRequest<int>
    {
        public int OwnerId { get; set; }
    }
}