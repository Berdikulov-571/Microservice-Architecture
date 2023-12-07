using Autorization.Api.Enums;

namespace Autorization.Api.Models
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get;set; }
        public Role Role { get; set; }
    }
}