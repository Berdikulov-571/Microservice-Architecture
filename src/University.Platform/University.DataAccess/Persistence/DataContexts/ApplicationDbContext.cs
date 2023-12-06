﻿using Microsoft.EntityFrameworkCore;
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
using University.Service.Abstractions.DataContexts;

namespace University.DataAccess.Persistence.DataContexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Admin> Admins { get ; set ; }
        public DbSet<Course> Courses { get ; set ; }
        public DbSet<Dedline> Dedlines { get ; set ; }
        public DbSet<Group> Groups { get ; set ; }
        public DbSet<Lesson> Lessons { get ; set ; }
        public DbSet<NB> Nbs { get ; set ; }
        public DbSet<Student> Students { get ; set ; }
        public DbSet<Subject> Subjects { get ; set ; }
        public DbSet<TaskGrade> TaskGrades { get ; set ; }
        public DbSet<Teacher> Teachers { get ; set ; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}