namespace University.Domain.Dtos.Courses
{
    public class CourseUpdateDto
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
    }
}