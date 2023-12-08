using Microsoft.AspNetCore.Http;
using University.Domain.Attributes.Email;
using University.Domain.Attributes.Length;
using University.Domain.Attributes.Password;

namespace University.Domain.Dtos.Admins
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