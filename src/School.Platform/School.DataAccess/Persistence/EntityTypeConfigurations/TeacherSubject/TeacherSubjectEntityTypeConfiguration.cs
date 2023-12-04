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
        }
    }
}