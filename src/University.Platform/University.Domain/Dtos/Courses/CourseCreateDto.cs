namespace University.Domain.Dtos.Courses
{
    public class CourseCreateDto
    {
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
    }
}