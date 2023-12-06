using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Subjects;
using University.Domain.Exceptions.Subjects;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Subjects.Queries.Get;

namespace University.Service.UseCases.Subjects.Handlers.Get
{
    public class GetSubjectByIdQueryHandler : IRequestHandler<GetSubjectByIdQuery, Subject>
    {
        private readonly IApplicationDbContext _context;

        public GetSubjectByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Subject> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken)
        {
            Subject? subject = await _context.Subjects.FirstOrDefaultAsync(x => x.SubjectId == request.SubjectId,cancellationToken);

            if (subject == null)
                throw new SubjectNotFound();

            return subject;
        }
    }
}