using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using University.Domain.Entities.Dedlines;

namespace University.DataAccess.Persistence.EntityTypeConfigurations.Dedlines
{
    public class DedlineEntityTypeConfiguration : IEntityTypeConfiguration<Dedline>
    {
        public void Configure(EntityTypeBuilder<Dedline> builder)
        {
            builder.HasKey(d => d.DedlineId);

            builder.HasOne(d => d.Course)
                .WithMany(c => c.Deadlines)
                .HasForeignKey(d => d.CourseId);
        }
    }
}