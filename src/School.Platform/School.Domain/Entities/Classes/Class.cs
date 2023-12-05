using School.Domain.Entities.Teachers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Domain.Entities.Classes
{
    public class Class
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassId { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(Teacher))]
        public int ClassTeacher { get; set; }
        public Teacher Teacher { get; set; }
        public int RoomNumber { get; set; }
    }
}