using School.Domain.Entities.ClassTasks;
using School.Domain.Entities.Persons;
using School.Domain.Entities.Subjects;
using School.Domain.Entities.TeacherSubjectRelation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Domain.Entities.Teachers
{
    public class Teacher : Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; }
        public ICollection<TeacherSubjects> TeacherSubjects { get; set; }
        public ICollection<ClassTask> ClassTasks { get; set; }
    }
}