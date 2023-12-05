using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Lessons;
using School.Domain.Exceptions.Lessons;
using School.Service.Abstractions.DataAccess;
using School.Service.UseCases.Lessons.Commands.Update;

namespace School.Service.UseCases.Lessons.Handlers.Update
{
    public class UpdateLessonCommandHandler : IRequestHandler<UpdateLessonCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateLessonCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
        {
            Lesson? lesson = await _context.Lessons.FirstOrDefaultAsync(x => x.LessonId == request.LessonId);

            if (lesson == null)
                throw new LessonNotFound();

            lesson.Theme = request.Theme;
            lesson.TeacherId = request.TeacherId;

            _context.Lessons.Update(lesson);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}