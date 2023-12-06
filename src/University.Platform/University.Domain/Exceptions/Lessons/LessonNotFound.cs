namespace University.Domain.Exceptions.Lessons
{
    public class LessonNotFound : GlobalException
    {
        public LessonNotFound()
        {
            TitleMessage = "Lesson Not Found !";
        }
    }
}