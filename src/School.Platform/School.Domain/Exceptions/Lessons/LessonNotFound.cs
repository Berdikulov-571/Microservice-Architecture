namespace School.Domain.Exceptions.Lessons
{
    public class LessonNotFound : NotFoundException
    {
        public LessonNotFound()
        {
            TitleMessage = "Lesson Not Found !";
        }
    }
}
