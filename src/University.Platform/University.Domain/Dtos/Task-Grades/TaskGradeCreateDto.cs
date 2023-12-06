using Microsoft.AspNetCore.Http;

namespace University.Domain.Dtos.Task_Grades
{
    public class TaskGradeCreateDto
    {
        public float GradeValue { get; set; }
        public int DedlineId { get; set; }
        public int StudentId { get; set; }
        public IFormFile File { get; set; }
        public bool IsUploaded { get; set; }
        public bool IsRated { get; set; }
    }
}