namespace School.Domain.Exceptions.Students
{
    public class StudentNotFound : NotFoundException
    {
        public StudentNotFound()
        {
            TitleMessage = "Student Not Found !";
        }
    }
}
