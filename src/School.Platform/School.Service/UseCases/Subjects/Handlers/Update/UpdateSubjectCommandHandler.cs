using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Subjects;
using School.Domain.Exceptions.Subjects;
using School.Service.Abstractions.DataAccess;
using School.Service.UseCases.Subjects.Commands.Update;

namespace School.Service.UseCases.Subjects.Handlers.Update
{
    public class UpdateSubjectCommandHandler : IRequestHandler<UpdateSubjectCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateSubjectCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {
            Subject? subject = await _context.Subjects.FirstOrDefaultAsync(x => x.SubjectId == request.SubjectId);

            if (subject == null)
                throw new SubjectNotFound();

            subject.Name = request.Name;

            _context.Subjects.Update(subject);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}