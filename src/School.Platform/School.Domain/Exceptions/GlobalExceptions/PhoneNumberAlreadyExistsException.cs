using System.Net;

namespace School.Domain.Exceptions.GlobalExceptions
{
    public class PhoneNumberAlreadyExistsException : Exception
    {
        private HttpStatusCode StatusCode { get; } = HttpStatusCode.Forbidden;
        private string TitleMessage { get; set; } = default!;

        public PhoneNumberAlreadyExistsException()
        {
            TitleMessage = "This PhoneNumber Already Exists Exception";
        }
    }
}
