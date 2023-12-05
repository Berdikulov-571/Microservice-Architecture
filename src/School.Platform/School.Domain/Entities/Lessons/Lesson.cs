using School.Domain.Entities.Teachers;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Domain.Entities.Lessons
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public string Theme { get; set; }
        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
    }
}