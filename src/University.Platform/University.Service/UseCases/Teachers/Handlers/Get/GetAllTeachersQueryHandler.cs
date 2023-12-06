using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Teachers;
using University.Domain.Exceptions.Teachers;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Teachers.Queries.Get;

namespace University.Service.UseCases.Teachers.Handlers.Get
{
    public class GetAllTeachersQueryHandler : IRequestHandler<GetAllTeacherQuery, IEnumerable<Teacher>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTeachersQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Teacher>> Handle(GetAllTeacherQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Teacher> teachers = await _context.Teachers.ToListAsync(cancellationToken);

            if (teachers == null)
                throw new TeacherNotFound();

            return teachers;
        }
    }
}