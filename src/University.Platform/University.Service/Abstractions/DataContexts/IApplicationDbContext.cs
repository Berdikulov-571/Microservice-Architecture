using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Admins;
using University.Domain.Entities.Courses;
using University.Domain.Entities.Dedlines;
using University.Domain.Entities.Groups;
using University.Domain.Entities.Lessons;
using University.Domain.Entities.MissedLessons;
using University.Domain.Entities.Students;
using University.Domain.Entities.Subjects;
using University.Domain.Entities.Task_Grades;
using University.Domain.Entities.Teachers;

namespace University.Service.Abstractions.DataContexts
{
    public interface IApplicationDbContext
    {
        DbSet<Admin> Admins { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<Dedline> Dedlines { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<Lesson> Lessons { get; set; }
        DbSet<NB> Nbs { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Subject> Subjects { get; set; }
        DbSet<TaskGrade> TaskGrades { get; set; }
        DbSet<Teacher> Teachers { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}