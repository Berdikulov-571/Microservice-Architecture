using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using University.Domain.Entities.Students;
using University.Domain.Exceptions.Students;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Students.Queries.Get;

namespace University.Service.UseCases.Students.Handlers.Get
{
    public class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentQuery, IEnumerable<Student>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDistributedCache _cache;

        public GetAllStudentQueryHandler(IApplicationDbContext context, IDistributedCache cache)
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