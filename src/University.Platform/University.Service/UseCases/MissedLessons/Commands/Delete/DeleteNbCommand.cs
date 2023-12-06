using MediatR;

namespace University.Service.UseCases.MissedLessons.Commands.Delete
{
    public class DeleteNbCommand : IRequest<int>
    {
        public int NbId { get; set; }
    }
}