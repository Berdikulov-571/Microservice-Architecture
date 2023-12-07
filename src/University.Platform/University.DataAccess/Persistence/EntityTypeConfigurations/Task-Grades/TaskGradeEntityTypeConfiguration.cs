using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using University.Domain.Entities.Task_Grades;

namespace University.DataAccess.Persistence.EntityTypeConfigurations.Task_Grades
{
    public class TaskGradeEntityTypeConfiguration : IEntityTypeConfiguration<TaskGrade>
    {
        public void Configure(EntityTypeBuilder<TaskGrade> builder)
        {
            builder.HasKey(tg => tg.TaskGradeId);

            builder.HasOne(tg => tg.Deadline)
                .WithMany(d => d.TaskGrades)
                .HasForeignKey(tg => tg.DedlineId);
        }
    }
}