using Autorization.Api.UNiverModels;
using Autorization.Api.UniversityModels;
using Microsoft.EntityFrameworkCore;

namespace Autorization.Api.DataContexts
{
    public class UniversityDatabase : DbContext
    {
        public UniversityDatabase(DbContextOptions<UniversityDatabase> options) : base(options)
        {
            
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}