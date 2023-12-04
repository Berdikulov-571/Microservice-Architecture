using System.Net;

namespace School.Domain.Exceptions.GlobalExceptions.AlreadyExistsExceptions
{
    public class EmailAlreadyExistsException
    {
        private HttpStatusCode StatusCode { get; } = HttpStatusCode.Forbidden;
        private string TitleMessage { get; set; } = default!;

        public EmailAlreadyExistsException()
        {
            TitleMessage = "This Email Already Exists !";
        }
    }
}