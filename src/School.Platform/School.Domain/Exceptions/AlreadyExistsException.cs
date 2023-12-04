using System.Net;

namespace School.Domain.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        public HttpStatusCode StatusCode { get; } = HttpStatusCode.Forbidden;
        public string TitleMessage { get; set; } = default!;
    }
}