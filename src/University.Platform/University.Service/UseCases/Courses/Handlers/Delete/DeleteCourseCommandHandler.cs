using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Courses;
using University.Domain.Exceptions.Courses;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Courses.Commands.Delete;

namespace University.Service.UseCases.Courses.Handlers.Delete
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCourseCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            Course? course = await _context.Courses.FirstOrDefaultAsync(x => x.CourseId == request.CourseId, cancellationToken);

            if (course == null)
                throw new CourseNotFound();

            _context.Courses.Remove(course);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}