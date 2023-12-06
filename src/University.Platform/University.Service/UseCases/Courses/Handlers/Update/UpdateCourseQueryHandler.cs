using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Courses;
using University.Domain.Exceptions.Courses;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Courses.Commands.Update;

namespace University.Service.UseCases.Courses.Handlers.Update
{
    public class UpdateCourseQueryHandler : IRequestHandler<UpdateCourseCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCourseQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            Course? course = await _context.Courses.FirstOrDefaultAsync(x => x.CourseId == request.CourseId, cancellationToken);

            if (course == null)
                throw new CourseNotFound();

            course.TeacherId = request.TeacherId;
            course.SubjectId = request.SubjectId;
            course.Name = request.Name;
            course.UpdateAt = DateTime.Now;

            _context.Courses.Update(course);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}