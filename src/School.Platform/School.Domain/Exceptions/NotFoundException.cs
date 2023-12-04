using System.Net;

namespace School.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;
        public string TitleMessage { get; set; } = default!;
    }
}
