using System.Net;

namespace School.Domain.Exceptions.GlobalExceptions
{
    public class PasswordNotValid : Exception
    {
        private HttpStatusCode StatusCode { get; } = HttpStatusCode.Forbidden;
        private string TitleMessage { get; set; } = default!;

        public PasswordNotValid()
        {
            TitleMessage = "Password Not Valid !";
        }
    }
}