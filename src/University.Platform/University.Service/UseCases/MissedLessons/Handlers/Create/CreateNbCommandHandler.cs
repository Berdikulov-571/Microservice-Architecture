using MediatR;
using University.Domain.Entities.MissedLessons;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.MissedLessons.Commands.Create;

namespace University.Service.UseCases.MissedLessons.Handlers.Create
{
    public class CreatenbCommandHandler : IRequestHandler<CreateNbCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreatenbCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateNbCommand request, CancellationToken cancellationToken)
        {
            NB nb = new NB()
            {
                LessonId = request.LessonId,
                StudentId = request.StudentId,
                IsAvailable = request.IsAvailable,
                CreatedAt = DateTime.Now,
            };

            await _context.Nbs.AddAsync(nb, cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}