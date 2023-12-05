using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Lessons;
using School.Domain.Exceptions.Lessons;
using School.Service.Abstractions.DataAccess;
using School.Service.UseCases.Lessons.Queries.Get;

namespace School.Service.UseCases.Lessons.Handlers.Get
{
    public class GetLessonByIdCommandHandler : IRequestHandler<GetLessonByIdQuery, Lesson>
    {
        private readonly IApplicationDbContext _context;

        public GetLessonByIdCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Lesson> Handle(GetLessonByIdQuery request, CancellationToken cancellationToken)
        {
            Lesson? lesson = await _context.Lessons.FirstOrDefaultAsync(x => x.LessonId == request.LessonId);

            if (lesson == null)
                throw new LessonNotFound();

            return lesson;
        }
    }
}