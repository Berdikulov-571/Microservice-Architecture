namespace University.Domain.Exceptions.Subjects
{
    public class SubjectNotFound : GlobalException
    {
        public SubjectNotFound()
        {
            TitleMessage = "Subject Not Found !";
        }
    }
}