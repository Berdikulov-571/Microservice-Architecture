using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Students;
using University.Domain.Exceptions.Students;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Students.Queries.Get;

namespace University.Service.UseCases.Students.Handlers.Get
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Student>
    {
        private readonly IApplicationDbContext _context;

        public GetStudentByIdQueryHandler(IApplicationDbContext context)
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