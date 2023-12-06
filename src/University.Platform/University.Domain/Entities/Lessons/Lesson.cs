using System.ComponentModel.DataAnnotations;
using University.Domain.Common.BaseEntities;
using University.Domain.Entities.Courses;
using University.Domain.Entities.MissedLessons;

namespace University.Domain.Entities.Lessons
{
    public class Lesson : Auditable
    {
        [Key]
        public int LessonId { get; set; }
        public string Name { get; set; }
        public string Lecture { get; set; }
        public DateTime Date { get; set; }
        public int CourseId { get; set; }

        public Course Course { get; set; }
        public ICollection<NB> NBs { get; set; }
    }
}