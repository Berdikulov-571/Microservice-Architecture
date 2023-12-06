using Microsoft.AspNetCore.Http;
using University.Domain.Enums.Genders;
using University.Domain.Enums.Roles;

namespace University.Domain.Dtos.Teachers
{
    public class TeacherUpdateDto
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public string AddressTemporary { get; set; }
        public string Salt { get; set; }
        public string PhoneNumber { get; set; }
        public IFormFile? ImagePath { get; set; }
    }
}