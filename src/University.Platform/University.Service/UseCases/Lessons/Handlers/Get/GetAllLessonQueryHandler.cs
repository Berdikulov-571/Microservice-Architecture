using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Lessons;
using University.Domain.Exceptions.Lessons;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Lessons.Queries.Get;

namespace University.Service.UseCases.Lessons.Handlers.Get
{
    public class GetAllLessonQueryHandler : IRequestHandler<GetAllLessonsQuery, IEnumerable<Lesson>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllLessonQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lesson>> Handle(GetAllLessonsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Lesson> lessons = await _context.Lessons.ToListAsync(cancellationToken);

            if (lessons == null)
                throw new LessonNotFound();

            return lessons;
        }
    }
}