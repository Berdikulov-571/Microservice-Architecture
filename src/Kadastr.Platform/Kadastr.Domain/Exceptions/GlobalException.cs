using System.Net;

namespace Kadastr.Domain.Exceptions
{
    public class GlobalException : Exception
    {
        public HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;
        public string TitleMessage { get; set; } = default!;
    }
}