using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using University.Domain.Common.BaseEntities;
using University.Domain.Entities.Courses;
using University.Domain.Entities.Task_Grades;

namespace University.Domain.Entities.Dedlines
{
    public class Dedline : Auditable
    {
        [Key]
        public int DedlineId { get; set; }
        public float MaxGrade { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string FilePath { get; set; }
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }

        public Course Course { get; set; }
        public ICollection<TaskGrade>? TaskGrades { get; set; }
    }
}