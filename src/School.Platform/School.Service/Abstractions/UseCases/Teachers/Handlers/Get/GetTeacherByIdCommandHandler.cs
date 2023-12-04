using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Teachers;
using School.Domain.Exceptions.Teacher;
using School.Service.Abstractions.DataAccess;
using School.Service.Abstractions.UseCases.Teachers.Queries.Get;

namespace School.Service.Abstractions.UseCases.Teachers.Handlers.Get
{
    public class GetTeacherByIdCommandHandler : IRequestHandler<GetTeacherByIdQuery, Teacher>
    {
        private readonly IApplicationDbContext _context;

        public GetTeacherByIdCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Teacher> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
        {
            Teacher? teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.TeacherId == request.TeacherId,cancellationToken);

            if (teacher == null)
                throw new TeacherNotFound();

            return teacher;
        }
    }
}
