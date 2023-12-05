using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.TeacherSubjectRelation;
using School.Domain.Exceptions.TeacherSubject;
using School.Service.Abstractions.DataAccess;
using School.Service.UseCases.TeacherSubjectRelation.Commands.Delete;

namespace School.Service.UseCases.TeacherSubjectRelation.Handlers.Delete
{
    public class DeleteTeacherSubjectCommandHandler : IRequestHandler<DeleteTeacherSubjectCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTeacherSubjectCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteTeacherSubjectCommand request, CancellationToken cancellationToken)
        {
            TeacherSubjects? teacherSubject = await _context.TeacherSubjects.FirstOrDefaultAsync(x => x.TeacherSubjectId == request.TeacherSubjectId);

            if (teacherSubject == null)
                throw new TeacherSubjectNotFound();

            _context.TeacherSubjects.Remove(teacherSubject);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}