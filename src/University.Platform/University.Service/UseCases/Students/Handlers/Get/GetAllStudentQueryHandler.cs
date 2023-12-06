using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Students;
using University.Domain.Exceptions.Students;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Students.Queries.Get;

namespace University.Service.UseCases.Students.Handlers.Get
{
    public class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentQuery, IEnumerable<Student>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllStudentQueryHandler(IApplicationDbContext context)
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