using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities.Students;
using System.Reflection.Emit;

namespace School.DataAccess.Persistence.EntityTypeConfigurations.Students
{
    public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.StudentId);

            builder.HasKey(s => s.StudentId);

            builder.HasOne(s => s.Class)
                .WithMany()
                .HasForeignKey(s => s.ClassId);
        }
    }
}
