using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Students;
using School.Domain.Exceptions.Students;
using School.Service.Abstractions.DataAccess;
using School.Service.UseCases.Students.Queries.Get;

namespace School.Service.UseCases.Students.Handlers.Get
{
    public class GetAllStudentCommandHandler : IRequestHandler<GetAllStudentQuery, IEnumerable<Student>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllStudentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Student> students = await _context.Students.ToListAsync(cancellationToken);

            if (students == null)
                throw new StudentNotFound();

            return students;
        }
    }
}
