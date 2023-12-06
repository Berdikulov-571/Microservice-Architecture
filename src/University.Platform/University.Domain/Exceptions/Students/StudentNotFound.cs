namespace University.Domain.Exceptions.Students
{
    public class StudentNotFound : GlobalException
    {
        public StudentNotFound()
        {
            TitleMessage = "Student Not Found !";
        }
    }
}