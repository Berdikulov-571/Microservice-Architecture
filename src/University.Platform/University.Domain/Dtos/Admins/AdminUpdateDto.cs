using Microsoft.AspNetCore.Http;

namespace University.Domain.Dtos.Admins
{
    public class AdminUpdateDto
    {
        public int AdminId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Passwor { get; set; }
        public string Email { get; set; }
        public IFormFile? ImagePath { get; set; }
    }
}