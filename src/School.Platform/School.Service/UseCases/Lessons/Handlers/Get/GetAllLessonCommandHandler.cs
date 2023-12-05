using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Lessons;
using School.Domain.Exceptions.Lessons;
using School.Service.Abstractions.DataAccess;
using School.Service.UseCases.Lessons.Queries.Get;

namespace School.Service.UseCases.Lessons.Handlers.Get
{
    public class GetAllLessonCommandHandler : IRequestHandler<GetAllLessonQuery, IEnumerable<Lesson>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllLessonCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lesson>> Handle(GetAllLessonQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Lesson>? lessons = await _context.Lessons.ToListAsync(cancellationToken);

            if (lessons == null)
                throw new LessonNotFound();

            return lessons;
        }
    }
}