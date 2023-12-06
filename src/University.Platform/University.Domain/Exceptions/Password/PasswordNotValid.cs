namespace University.Domain.Exceptions.Password
{
    public class PasswordNotValid : GlobalException
    {
        public PasswordNotValid()
        {
            TitleMessage = "Password Not Valid !";
        }
    }
}