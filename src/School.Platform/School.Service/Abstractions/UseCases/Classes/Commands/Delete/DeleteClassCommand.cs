using MediatR;

namespace School.Service.Abstractions.UseCases.Classes.Commands.Delete
{
    public class DeleteClassCommand : IRequest<int>
    {
        public int ClassId { get; set; }
    }
}