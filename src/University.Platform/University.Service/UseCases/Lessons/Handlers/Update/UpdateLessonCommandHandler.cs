using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Lessons;
using University.Domain.Exceptions.Lessons;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Lessons.Commands.Update;

namespace University.Service.UseCases.Lessons.Handlers.Update
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
            Lesson? lesson = await _context.Lessons.FirstOrDefaultAsync(x => x.LessonId == request.LessonId,cancellationToken);

            if (lesson == null)
                throw new LessonNotFound();

            lesson.Name = request.Name;
            lesson.Date = request.Date;
            lesson.Lecture = request.Lecture;
            lesson.CourseId = request.CourseId;
            lesson.UpdateAt = DateTime.Now;

            _context.Lessons.Update(lesson);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}