using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities.Lessons;
using System.Reflection.Emit;

namespace School.DataAccess.Persistence.EntityTypeConfigurations.Lessons
{
    public class LessonEntityTypeConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(x => x.LessonId);

            builder.HasKey(l => l.LessonId);

            builder.HasOne(l => l.Teacher)
                .WithMany()
                .HasForeignKey(l => l.TeacherId);
        }
    }
}