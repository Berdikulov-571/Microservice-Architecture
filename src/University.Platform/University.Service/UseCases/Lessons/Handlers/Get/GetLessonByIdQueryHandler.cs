using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Lessons;
using University.Domain.Exceptions.Lessons;
using University.Service.Abstractions.DataContexts;
using University.Service.UseCases.Lessons.Queries.Get;

namespace University.Service.UseCases.Lessons.Handlers.Get
{
    public class GetLessonByIdQueryHandler : IRequestHandler<GetLessonByIdQuery, Lesson>
    {
        private readonly IApplicationDbContext _context;

        public GetLessonByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Lesson> Handle(GetLessonByIdQuery request, CancellationToken cancellationToken)
        {
            Lesson? lesson = await _context.Lessons.FirstOrDefaultAsync(x => x.LessonId == request.LessonId, cancellationToken);

            if (lesson == null)
                throw new LessonNotFound();

            return lesson;
        }
    }
}