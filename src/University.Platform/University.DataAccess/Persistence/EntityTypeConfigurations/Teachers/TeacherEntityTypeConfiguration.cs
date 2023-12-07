using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using University.Domain.Entities.Teachers;

namespace University.DataAccess.Persistence.EntityTypeConfigurations.Teachers
{
    public class TeacherEntityTypeConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(t => t.TeacherId);

            builder.HasMany(t => t.Courses)
                .WithOne(c => c.Teacher)
                .HasForeignKey(c => c.TeacherId);
        }
    }
}