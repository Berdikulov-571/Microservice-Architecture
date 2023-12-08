using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities.Task;
using System.Reflection.Emit;

namespace School.DataAccess.Persistence.EntityTypeConfigurations.Task
{
    public class TaskEntityTypeConfiguration : IEntityTypeConfiguration<Tasks>
    {
        public void Configure(EntityTypeBuilder<Tasks> builder)
        {
            builder.HasKey(x => x.TaskId);
        }
    }
}
