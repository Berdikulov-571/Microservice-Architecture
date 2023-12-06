using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using University.Domain.Common.BaseEntities;
using University.Domain.Entities.Lessons;
using University.Domain.Entities.Students;

namespace University.Domain.Entities.MissedLessons
{
    public class NB : Auditable
    {
        [Key]
        public int NbId { get; set; }
        public bool IsAvailable { get; set; }
        [ForeignKey(nameof(Lesson))]
        public int LessonId { get; set; }
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }

        public Lesson? Lesson { get; set; }
        public Student? Student { get; set; }
    }
}