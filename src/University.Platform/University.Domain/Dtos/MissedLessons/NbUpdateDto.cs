namespace University.Domain.Dtos.MissedLessons
{
    public class NbUpdateDto
    {
        public int NbId { get; set; }
        public bool IsAvailable { get; set; }
        public int LessonId { get; set; }
        public int StudentId { get; set; }
    }
}