using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Subjects;
using University.Domain.Exceptions.Subjects;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Subjects.Commands.Delete;

namespace University.Service.UseCases.Subjects.Handlers.Delete
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
            Subject? subject = await _context.Subjects.FirstOrDefaultAsync(x => x.SubjectId == request.SubjectId,cancellationToken);

            if (subject == null)
                throw new SubjectNotFound();

            _context.Subjects.Remove(subject);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}