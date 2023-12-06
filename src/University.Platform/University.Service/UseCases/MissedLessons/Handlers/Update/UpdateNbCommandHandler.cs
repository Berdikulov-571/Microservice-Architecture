using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.MissedLessons;
using University.Domain.Exceptions.MissedLessons;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.MissedLessons.Commands.Update;

namespace University.Service.UseCases.MissedLessons.Handlers.Update
{
    public class UpdateNbCommandHandler : IRequestHandler<UpdateNbCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateNbCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateNbCommand request, CancellationToken cancellationToken)
        {
            NB? nb = await _context.Nbs.FirstOrDefaultAsync(x => x.NbId == request.NbId, cancellationToken);

            if (nb == null)
                throw new NbNotFound();

            nb.LessonId = request.LessonId;
            nb.StudentId = request.StudentId;
            nb.IsAvailable = request.IsAvailable;
            nb.UpdateAt = DateTime.Now;

            _context.Nbs.Update(nb);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}