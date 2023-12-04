namespace School.Domain.Exceptions.Subjects
{
    public class SubjectNotFound : NotFoundException
    {
        public SubjectNotFound()
        {
            TitleMessage = "Subject Not Found !";
        }
    }
}