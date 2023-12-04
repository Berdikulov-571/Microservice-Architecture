using School.Domain.Entities.Subjects;
using School.Domain.Entities.Teachers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Domain.Entities.TeacherSubjectRelation
{
    public class TeacherSubjects
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherSubjectId { get; set; }
        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }
        [ForeignKey(nameof(Subject))]
        public int SubjectId { get; set; }
        public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }
    }
}