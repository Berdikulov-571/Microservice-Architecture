using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Courses;
using University.Domain.Exceptions.Courses;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Courses.Queries.Get;

namespace University.Service.UseCases.Courses.Handlers.Get
{
    public class GetAllCourseQueryHandler : IRequestHandler<GetAllCourseQuery, IEnumerable<Course>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllCourseQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Course> course = await _context.Courses.ToListAsync(cancellationToken);

            if (course == null)
                throw new CourseNotFound();

            return course;
        }
    }
}