using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using School.Domain.Dtos.Images;
using School.Domain.Entities.Students;
using School.Domain.Exceptions.Students;
using School.Service.Abstractions.DataAccess;
using School.Service.UseCases.Students.Queries.Get;

namespace School.Service.UseCases.Students.Handlers.Get
{
    public class GetStudentByIdCommandHandler : IRequestHandler<GetStudentByIdQuery, Student>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDistributedCache _distributedCache;
        public GetStudentByIdCommandHandler(IApplicationDbContext context, IDistributedCache distributedCache)
        {
            _context = context;
            _distributedCache = distributedCache;
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
