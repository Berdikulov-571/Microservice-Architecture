using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Subjects;
using University.Domain.Exceptions.Subjects;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Subjects.Queries.Get;

namespace University.Service.UseCases.Subjects.Handlers.Get
{
    public class GetAllSubjectQueryHandler : IRequestHandler<GetAllSubjectQuery, IEnumerable<Subject>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllSubjectQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Subject>> Handle(GetAllSubjectQuery request, CancellationToken cancellationToken)
        {
            List<Subject> subjects = await _context.Subjects.ToListAsync(cancellationToken);

            if (subjects == null)
                throw new SubjectNotFound();

            return subjects;
        }
    }
}