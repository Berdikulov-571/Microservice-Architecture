using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Subjects;
using School.Domain.Exceptions.Subjects;
using School.Service.Abstractions.DataAccess;
using School.Service.UseCases.Subjects.Queries.Get;

namespace School.Service.UseCases.Subjects.Handlers.Get
{
    public class GetSubjectByIdCommandHandler : IRequestHandler<GetSubjectByIdQuery, Subject>
    {
        private readonly IApplicationDbContext _context;

        public GetSubjectByIdCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Subject> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken)
        {
            Subject? subject = await _context.Subjects.FirstOrDefaultAsync(x => x.SubjectId == request.SubjectId, cancellationToken);

            if (subject == null)
                throw new SubjectNotFound();

            return subject;
        }
    }
}