using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using University.Domain.Entities.MissedLessons;

namespace University.DataAccess.Persistence.EntityTypeConfigurations.MissedLessons
{
    public class NbEntityTypeConfiguration : IEntityTypeConfiguration<NB>
    {
        public void Configure(EntityTypeBuilder<NB> builder)
        {
            builder.HasKey(nb => nb.NbId);

            builder.HasOne(nb => nb.Lesson)
                .WithMany(l => l.NBs)
                .HasForeignKey(nb => nb.LessonId);
        }
    }
}