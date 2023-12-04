using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities.ClassTasks;

namespace School.DataAccess.Persistence.EntityTypeConfigurations.ClassTasks
{
    public class ClassTaskEntityTypeConfiguration : IEntityTypeConfiguration<ClassTask>
    {
        public void Configure(EntityTypeBuilder<ClassTask> builder)
        {
            builder.HasKey(x => x.ClassTaskId);
        }
    }
}
