using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Teachers;
using School.Domain.Exceptions.Teacher;
using School.Service.Abstractions.DataAccess;
using School.Service.Abstractions.UseCases.Teachers.Queries.Get;

namespace School.Service.Abstractions.UseCases.Teachers.Handlers.Get
{
    public class GetAllTeacherCommandHandler : IRequestHandler<GetAllTeacherQuery, IEnumerable<Teacher>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTeacherCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Teacher>> Handle(GetAllTeacherQuery request, CancellationToken cancellationToken)
        {
            List<Teacher> teachers = await _context.Teachers.ToListAsync(cancellationToken);

            if (teachers == null)
                throw new TeacherNotFound();

            return teachers;
        }
    }
}
