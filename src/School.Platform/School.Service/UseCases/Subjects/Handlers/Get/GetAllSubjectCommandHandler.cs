using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Subjects;
using School.Domain.Exceptions.Subjects;
using School.Service.Abstractions.DataAccess;
using School.Service.UseCases.Subjects.Queries.Get;

namespace School.Service.UseCases.Subjects.Handlers.Get
{
    public class GetAllSubjectCommandHandler : IRequestHandler<GetAllSubjecttQuery, IEnumerable<Subject>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllSubjectCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Subject>> Handle(GetAllSubjecttQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Subject> subjects = await _context.Subjects.ToListAsync(cancellationToken);

            if (subjects == null)
                throw new SubjectNotFound();

            return subjects;
        }
    }
}