using MediatR;
using School.Domain.Entities.Lessons;
using School.Service.Abstractions.DataAccess;
using School.Service.UseCases.Lessons.Commands.Create;

namespace School.Service.UseCases.Lessons.Handlers.Create
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
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMinutes(45),
                Theme = request.Theme,
                TeacherId = request.TeacherId,
            };

            await _context.Lessons.AddAsync(lesson, cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}