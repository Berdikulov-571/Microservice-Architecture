using System.Net;

namespace School.Domain.Exceptions.GlobalExceptions.AlreadyExistsExceptions
{
    public class UserNameAlreadyExistsException : Exception
    {
        private HttpStatusCode StatusCode { get; } = HttpStatusCode.Forbidden;
        private string TitleMessage { get; set; } = default!;

        public UserNameAlreadyExistsException()
        {
            TitleMessage = "This UserName Already Exists !";
        }
    }
}