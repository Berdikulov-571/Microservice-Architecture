using MediatR;

namespace University.Service.UseCases.Dedlines.Commands.Delete
{
    public class DeleteDedlineCommand : IRequest<int>
    {
        public int DedlineId { get; set; }
    }
}