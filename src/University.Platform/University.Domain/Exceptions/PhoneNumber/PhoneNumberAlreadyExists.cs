namespace University.Domain.Exceptions.PhoneNumber
{
    public class PhoneNumberAlreadyExists : GlobalException
    {
        public PhoneNumberAlreadyExists()
        {
            TitleMessage = "Phone Number Already Exists !";
        }
    }
}