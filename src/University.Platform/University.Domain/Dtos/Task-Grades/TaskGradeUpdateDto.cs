using Microsoft.AspNetCore.Http;

namespace University.Domain.Dtos.Task_Grades
{
    public class TaskGradeUpdateDto
    {
        public int TaskGradeId { get; set; }
        public float GradeValue { get; set; }
        public int DedlineId { get; set; }
        public int StudentId { get; set; }
        public IFormFile File { get; set; }
        public bool IsUploaded { get; set; }
        public bool IsRated { get; set; }
    }
}