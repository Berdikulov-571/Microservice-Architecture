namespace University.Domain.Dtos.Lessons
{
    public class LessonCreateDto
    {
        public string Name { get; set; }
        public string Lecture { get; set; }
        public DateTime Date { get; set; }
        public int CourseId { get; set; }
    }
}