using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities.Admins;
using School.Service.Security.Password;

namespace School.DataAccess.Persistence.EntityTypeConfigurations.Admins
{
    public class AdminEntityTypeConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(x => x.AdminId);

            builder.HasData(new Admin()
            {
                AdminId = 1,
                Email = "bsanjarbek06@gmail.com",
                FirstName = "Sanjarbek",
                LastName = "Berdikulov",
                PasswordHash = Hash512.ComputeSHA512HashFromString("sanjarbek2006"),
                Role = Domain.Enums.RoleEnum.Role.SuperAdmin,
                UserName = "Berdikulov_571",
                CreatedAt = DateTime.Now,
            });
        }
    }
}