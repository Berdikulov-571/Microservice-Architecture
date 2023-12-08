using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities.TeacherSubjectRelation;

namespace School.DataAccess.Persistence.EntityTypeConfigurations.TeacherSubject
{
    public class TeacherSubjectEntityTypeConfiguration : IEntityTypeConfiguration<TeacherSubjects>
    {
        public void Configure(EntityTypeBuilder<TeacherSubjects> builder)
        {
            builder.HasKey(x => x.TeacherSubjectId);

            builder.HasOne(ts => ts.Teacher)
            .WithMany(t => t.TeacherSubjects)
            .HasForeignKey(ts => ts.TeacherId);

            builder.HasOne(ts => ts.Subject)
                .WithMany()
                .HasForeignKey(ts => ts.SubjectId);
        }
    }
}