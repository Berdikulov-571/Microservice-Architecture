namespace University.Domain.Exceptions.Teachers
{
    public class TeacherNotFound : GlobalException
    {
        public TeacherNotFound()
        {
            TitleMessage = "Teacher Not Found !s";
        }
    }
}