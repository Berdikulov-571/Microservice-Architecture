using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using University.Domain.Common.BaseEntities;
using University.Domain.Entities.Dedlines;
using University.Domain.Entities.Students;

namespace University.Domain.Entities.Task_Grades
{
    public class TaskGrade : Auditable
    {
        [Key]
        public int TaskGradeId { get; set; }
        public float GradeValue { get; set; }
        [ForeignKey(nameof(Deadline))]
        public int DedlineId { get; set; }
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        public string FilePath { get; set; }
        public bool IsUploaded { get; set; }
        public bool IsRated { get; set; }

        public Dedline Deadline { get; set; }
        public Student Student { get; set; }
    }
}