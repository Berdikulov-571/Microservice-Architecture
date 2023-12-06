namespace University.Domain.Exceptions.UserName
{
    public class UserNameAlreadyExists : GlobalException
    {
        public UserNameAlreadyExists()
        {
            TitleMessage = "UserName Alreay Exists !";
        }
    }
}