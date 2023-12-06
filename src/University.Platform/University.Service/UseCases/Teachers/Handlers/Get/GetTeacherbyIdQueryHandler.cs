using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Teachers;
using University.Domain.Exceptions.Teachers;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Teachers.Queries.Get;

namespace University.Service.UseCases.Teachers.Handlers.Get
{
    public class GetTeacherbyIdQueryHandler : IRequestHandler<GetTeacherByIdQuery, Teacher>
    {
        private readonly IApplicationDbContext _context;

        public GetTeacherbyIdQueryHandler(IApplicationDbContext context)
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