namespace University.Domain.Exceptions.PhoneNumber
{
    public class PhoneNumberNotValid : GlobalException
    {
        public PhoneNumberNotValid()
        {
            TitleMessage = "PhoneNumber Not Valid !";
        }
    }
}