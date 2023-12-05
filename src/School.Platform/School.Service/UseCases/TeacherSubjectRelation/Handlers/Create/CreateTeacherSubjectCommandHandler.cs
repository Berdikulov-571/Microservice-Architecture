using MediatR;
using School.Domain.Entities.TeacherSubjectRelation;
using School.Service.Abstractions.DataAccess;
using School.Service.UseCases.TeacherSubjectRelation.Commands.Create;

namespace School.Service.UseCases.TeacherSubjectRelation.Handlers.Create
{
    public class CreateTeacherSubjectCommandHandler : IRequestHandler<CreateTeacherSubjectCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateTeacherSubjectCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTeacherSubjectCommand request, CancellationToken cancellationToken)
        {
            TeacherSubjects teacherSubjects = new TeacherSubjects()
            {
                SubjectId = request.SubjectId,
                TeacherId = request.TeacherId,
            };

            await _context.TeacherSubjects.AddAsync(teacherSubjects, cancellationToken);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}