using System.ComponentModel.DataAnnotations;
using University.Domain.Common.BaseEntities;
using University.Domain.Entities.Courses;
using University.Domain.Entities.Students;

namespace University.Domain.Entities.Groups
{
    public class Group : Auditable
    {
        [Key]
        public int GroupId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }

        public ICollection<Student>? Students { get; set; }
        public ICollection<Course>? Courses { get; set; }
    }
}