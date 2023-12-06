using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Courses;
using University.Domain.Exceptions.Courses;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Courses.Queries.Get;

namespace University.Service.UseCases.Courses.Handlers.Get
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, Course>
    {
        private readonly IApplicationDbContext _context;

        public GetCourseByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Course> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            Course? course = await _context.Courses.FirstOrDefaultAsync(x => x.CourseId == request.CourseId,cancellationToken);

            if (course == null)
                throw new CourseNotFound();

            return course;
        }
    }
}