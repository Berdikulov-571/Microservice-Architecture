namespace School.Domain.Dtos.Lessons
{
    public class LessonUpdateDto
    {
        public int LessonId { get; set; }
        public string Theme { get; set; }
        public int TeacherId { get; set; }
    }
}
