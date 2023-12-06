using MediatR;

namespace University.Service.UseCases.Groups.Commands.Delete
{
    public class DeleteGroupCommand : IRequest<int>
    {
        public int GroupId { get; set; }
    }
}