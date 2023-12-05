using System.Net;

namespace School.Domain.Exceptions.GlobalExceptions.AlreadyExistsExceptions
{
    public class SubjectAlreadyExistsException : Exception
    {
        private HttpStatusCode StatusCode { get; } = HttpStatusCode.Forbidden;
        private string TitleMessage { get; set; } = default!;

        public SubjectAlreadyExistsException()
        {
            TitleMessage = "This Subject Already Already Exists !";
        }
    }
}