using MediatR;
using University.Domain.Entities.Courses;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Courses.Commands.Create;

namespace University.Service.UseCases.Courses.Handlers.Create
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateCourseCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            Course course = new Course()
            {
                Name = request.Name,
                SubjectId = request.SubjectId,
                TeacherId = request.TeacherId,
                CreatedAt = DateTime.Now,
            };

            await _context.Courses.AddAsync(course,cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}