using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Students;
using School.Domain.Exceptions.Students;
using School.Service.Abstractions.DataAccess;
using School.Service.Abstractions.UseCases.Students.Queries.Get;

namespace School.Service.Abstractions.UseCases.Students.Handlers.Get
{
    public class GetStudentByIdCommandHandler : IRequestHandler<GetStudentByIdQuery, Student>
    {
        private readonly IApplicationDbContext _context;

        public GetStudentByIdCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Student> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            Student? student = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == request.StudentId, cancellationToken);

            if (student == null)
                throw new StudentNotFound();

            return student;
        }
    }
}
