using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.MissedLessons;
using University.Domain.Exceptions.MissedLessons;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.MissedLessons.Commands.Delete;

namespace University.Service.UseCases.MissedLessons.Handlers.Delete
{
    public class DeleteNbCommanHandler : IRequestHandler<DeleteNbCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteNbCommanHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteNbCommand request, CancellationToken cancellationToken)
        {
            NB? nb = await _context.Nbs.FirstOrDefaultAsync(x => x.NbId == request.NbId,cancellationToken);

            if (nb == null)
                throw new NbNotFound();

            _context.Nbs.Remove(nb);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}