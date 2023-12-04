using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.Admins;
using School.Domain.Entities.Classes;
using School.Domain.Entities.ClassTasks;
using School.Domain.Entities.Lessons;
using School.Domain.Entities.Students;
using School.Domain.Entities.Subjects;
using School.Domain.Entities.Task;
using School.Domain.Entities.Teachers;
using School.Domain.Entities.TeacherSubjectRelation;

namespace School.Service.Abstractions.DataAccess
{
    public interface IApplicationDbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassTask> ClassTasks { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherSubjects> TeacherSubjects { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}