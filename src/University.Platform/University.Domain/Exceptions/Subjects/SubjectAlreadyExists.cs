namespace University.Domain.Exceptions.Subjects
{
    public class SubjectAlreadyExists : GlobalException
    {
        public SubjectAlreadyExists()
        {
            TitleMessage = "Subject Already Exists !";
        }
    }
}