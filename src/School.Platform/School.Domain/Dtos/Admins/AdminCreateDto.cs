using Microsoft.AspNetCore.Http;
using School.Domain.Attributes.Email;
using School.Domain.Attributes.Length;
using School.Domain.Attributes.Password;

namespace School.Domain.Dtos.Admins
{
    public class AdminCreateDto
    {
        [Length]
        public string UserName { get; set; }
        [Length]
        public string FirstName { get; set; }
        [Length]
        public string LastName { get; set; }
        [Password]
        public string Password { get; set; }
        [Email]
        public string Email { get; set; }
        public IFormFile ImagePath { get; set; }
    }
}
