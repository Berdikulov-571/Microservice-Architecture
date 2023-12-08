using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities.Classes;
using System.Reflection.Emit;

namespace School.DataAccess.Persistence.EntityTypeConfigurations.Classes
{
    public class ClassEntityTypeConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(x => x.ClassId);

            builder.HasOne(c => c.Teacher)
            .WithMany()
            .HasForeignKey(c => c.ClassTeacher);
        }
    }
}
