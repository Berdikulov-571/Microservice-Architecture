using MediatR;
using University.Domain.Entities.Lessons;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Lessons.Commands.Create;

namespace University.Service.UseCases.Lessons.Handlers.Create
{
    public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateLessonCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
        {
            Lesson lesson = new Lesson()
            {
                Name = request.Name,
                Date = request.Date,
                Lecture = request.Lecture,
                CourseId = request.CourseId,
                CreatedAt = DateTime.Now,
            };

            await _context.Lessons.AddAsync(lesson,cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}