namespace School.Domain.Exceptions.Teacher
{
    public class TeacherNotFound : NotFoundException
    {
        public TeacherNotFound()
        {
            TitleMessage = "Teacher Not Found !";
        }
    }
}