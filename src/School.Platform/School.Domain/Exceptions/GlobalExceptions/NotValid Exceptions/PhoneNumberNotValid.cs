using System.Net;

namespace School.Domain.Exceptions.GlobalExceptions.NotValid_Exceptions
{
    public class PhoneNumberNotValid
    {
        private HttpStatusCode StatusCode { get; } = HttpStatusCode.Forbidden;
        private string TitleMessage { get; set; } = default!;

        public PhoneNumberNotValid()
        {
            TitleMessage = "Phone Number Not Valid !";
        }
    }
}
