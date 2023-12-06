namespace University.Domain.Exceptions.Email
{
    public class EmailAlreadyExists : GlobalException
    {
        public EmailAlreadyExists()
        {
            TitleMessage = "Email Alreay Exists !";
        }
    }
}