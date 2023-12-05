using School.Domain.Entities.TeacherSubjectRelation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Domain.Entities.Subjects
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public ICollection<TeacherSubjects> TeacherSubjects { get; set; }
    }
}
