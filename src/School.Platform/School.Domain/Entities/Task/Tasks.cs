using School.Domain.Entities.ClassTasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Domain.Entities.Task
{
    public class Tasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }
        public string Description { get; set; }
        public ICollection<ClassTask> ClassTasks { get; set; }
    }
}