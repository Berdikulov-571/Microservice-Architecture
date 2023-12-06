using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using University.Domain.Common.BaseEntities;
using University.Domain.Entities.Dedlines;
using University.Domain.Entities.Groups;
using University.Domain.Entities.Lessons;
using University.Domain.Entities.Subjects;
using University.Domain.Entities.Teachers;

namespace University.Domain.Entities.Courses
{
    public class Course : Auditable
    {
        [Key]
        public int CourseId { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }
        [ForeignKey(nameof(Subject))]
        public int SubjectId { get; set; }

        public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }
        public ICollection<Lesson>? Lessons { get; set; }
        public ICollection<Dedline>? Deadlines { get; set; }
        public ICollection<Group>? Groups { get; set; }
    }
}