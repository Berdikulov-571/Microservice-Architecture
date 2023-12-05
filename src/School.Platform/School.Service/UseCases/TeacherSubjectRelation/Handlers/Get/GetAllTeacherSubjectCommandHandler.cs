using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Subjects;
using School.Service.Abstractions.DataAccess;
using School.Service.UseCases.TeacherSubjectRelation.Queries.Get;

namespace School.Service.UseCases.TeacherSubjectRelation.Handlers.Get
{
    public class GetAllTeacherSubjectCommandHandler : IRequestHandler<GetAllTeacherSubjectQuery, IEnumerable<Subject>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTeacherSubjectCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Subject>> Handle(GetAllTeacherSubjectQuery request, CancellationToken cancellationToken)
        {
            List<Subject> subjects = await _context.Subjects.Include(x => x.TeacherSubjects).ThenInclude(x => x.Teacher).ToListAsync(cancellationToken);

            return subjects;
        }
    }
}