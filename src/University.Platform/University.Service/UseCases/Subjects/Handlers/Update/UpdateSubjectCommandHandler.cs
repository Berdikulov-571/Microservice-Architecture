using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Subjects;
using University.Domain.Exceptions.Subjects;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Subjects.Commands.Update;

namespace University.Service.UseCases.Subjects.Handlers.Update
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
            Subject? subject = await _context.Subjects.SingleOrDefaultAsync(x => x.SubjectId == request.SubjectId, cancellationToken);

            if (subject == null)
                throw new SubjectNotFound();

            subject.Name = request.Name;
            subject.UpdateAt = DateTime.Now;

            _context.Subjects.Update(subject);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}