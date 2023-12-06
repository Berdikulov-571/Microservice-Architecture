namespace University.Domain.Exceptions.Courses
{
    public class CourseNotFound : GlobalException
    {
        public CourseNotFound()
        {
            TitleMessage = "Course Not Found !";
        }
    }
}