using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Lessons;
using School.Domain.Exceptions.Lessons;
using School.Service.Abstractions.DataAccess;
using School.Service.UseCases.Lessons.Commands.Delete;

namespace School.Service.UseCases.Lessons.Handlers.Delete
{
    public class DeleteLessonCommandHandler : IRequestHandler<DeleteLessonCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteLessonCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteLessonCommand request, CancellationToken cancellationToken)
        {
            Lesson? lesson = await _context.Lessons.FirstOrDefaultAsync(x => x.LessonId == request.LessonId, cancellationToken);

            if (lesson == null)
                throw new LessonNotFound();

            _context.Lessons.Remove(lesson);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}