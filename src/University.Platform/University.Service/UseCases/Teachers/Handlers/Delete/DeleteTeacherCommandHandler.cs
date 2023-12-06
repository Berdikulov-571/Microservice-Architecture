using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Teachers;
using University.Domain.Exceptions.Teachers;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Teachers.Commands.Delete;

namespace University.Service.UseCases.Teachers.Handlers.Delete
{
    public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTeacherCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            Teacher? teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.TeacherId == request.TeacherId, cancellationToken);

            if (teacher == null)
                throw new TeacherNotFound();

            _context.Teachers.Remove(teacher);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}