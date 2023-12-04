using Microsoft.AspNetCore.Http;
using School.Domain.Enums.RoleEnum;

namespace School.Domain.Dtos.Admins
{
    public class AdminCreateDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public IFormFile ImagePath { get; set; }
    }
}
