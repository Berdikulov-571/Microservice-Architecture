using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities.ClassTasks;
using System.Reflection.Emit;

namespace School.DataAccess.Persistence.EntityTypeConfigurations.ClassTasks
{
    public class ClassTaskEntityTypeConfiguration : IEntityTypeConfiguration<ClassTask>
    {
        public void Configure(EntityTypeBuilder<ClassTask> builder)
        {
            builder.HasKey(x => x.ClassTaskId);

            builder.HasOne(ct => ct.Teacher)
            .WithMany()
            .HasForeignKey(ct => ct.TeacherId);

            builder.HasOne(ct => ct.Task)
            .WithMany()
            .HasForeignKey(ct => ct.TaskId);
        }
    }
}
