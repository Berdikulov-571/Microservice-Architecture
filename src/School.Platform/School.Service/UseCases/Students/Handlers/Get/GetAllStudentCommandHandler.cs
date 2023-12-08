using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using School.Domain.Entities.Students;
using School.Domain.Exceptions.Students;
using School.Service.Abstractions.DataAccess;
using School.Service.UseCases.Students.Queries.Get;

namespace School.Service.UseCases.Students.Handlers.Get
{
    public class GetAllStudentCommandHandler : IRequestHandler<GetAllStudentQuery, IEnumerable<Student>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDistributedCache _cache;

        public GetAllStudentCommandHandler(IApplicationDbContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<IEnumerable<Student>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
        {

            string? response = _cache.GetString("GetAllStudents");

            if (response != null)
            {
                var cacheStudents = JsonConvert.DeserializeObject<List<Student>>(response);

                return cacheStudents;
            }

            IEnumerable<Student> students = await _context.Students.ToListAsync(cancellationToken);

            if (students == null)
                throw new StudentNotFound();
            
            return students;
        }
    }
}