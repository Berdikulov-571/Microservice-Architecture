using System.Net;

namespace University.Domain.Exceptions
{
    public class GlobalException : Exception
    {
        public HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;
        public string TitleMessage { get; set; } = default!;
    }
}