using MediatR;
using School.Domain.Entities.Subjects;
using School.Service.Abstractions.DataAccess;
using School.Service.UseCases.TeacherSubjectRelation.Queries.Get;

namespace School.Service.UseCases.TeacherSubjectRelation.Handlers.Get
{
    public class GetTeacherSubjectByTeacherIdCommandHandler : IRequestHandler<GetTeacherSubjectByTeacherIdQuery, IEnumerable<Subject>>
    {
        private readonly IApplicationDbContext _context;

        public GetTeacherSubjectByTeacherIdCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Subject>> Handle(GetTeacherSubjectByTeacherIdQuery request, CancellationToken cancellationToken)
        {
            var subjects = _context.TeacherSubjects
            .Where(ts => ts.TeacherId == request.TeacherId)
            .Select(ts => ts.Subject)
            .ToList();

            return subjects;
        }
    }
}