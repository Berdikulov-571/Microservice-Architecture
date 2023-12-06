using System.ComponentModel.DataAnnotations;
using University.Domain.Common.BaseEntities;
using University.Domain.Entities.Courses;

namespace University.Domain.Entities.Subjects
{
    public class Subject : Auditable
    {
        [Key]
        public int SubjectId { get; set; }
        public string Name { get; set; }

        public ICollection<Course>? Courses { get; set; }
    }
}