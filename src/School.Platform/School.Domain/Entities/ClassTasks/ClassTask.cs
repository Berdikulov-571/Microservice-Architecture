using School.Domain.Entities.Task;
using School.Domain.Entities.Teachers;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Domain.Entities.ClassTasks
{
    public class ClassTask
    {
        public int ClassTaskId { get; set; }
        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }
        [ForeignKey(nameof(Task))]
        public int TaskId { get; set; }
        public Teacher Teacher { get; set; }
        public Tasks Task { get; set; }
        public string Day { get; set; } = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
    }
}