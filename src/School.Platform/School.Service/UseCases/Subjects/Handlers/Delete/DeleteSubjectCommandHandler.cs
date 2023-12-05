using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Subjects;
using School.Domain.Exceptions.Subjects;
using School.Service.Abstractions.DataAccess;
using School.Service.UseCases.Subjects.Commands.Delete;

namespace School.Service.UseCases.Subjects.Handlers.Delete
{
    public class DeleteSubjectCommandHandler : IRequestHandler<DeleteSubjectCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteSubjectCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            Subject? subject = await _context.Subjects.FirstOrDefaultAsync(x => x.SubjectId == request.SubjectId);

            if (subject == null)
                throw new SubjectNotFound();

            _context.Subjects.Remove(subject);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}