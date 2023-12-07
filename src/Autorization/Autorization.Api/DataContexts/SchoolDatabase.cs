using Autorization.Api.SchoolModel;
using Microsoft.EntityFrameworkCore;

namespace Autorization.Api.DataContexts
{
    public class SchoolDatabase : DbContext
    {
        public SchoolDatabase(DbContextOptions<SchoolDatabase> options) : base(options)
        {
            
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}