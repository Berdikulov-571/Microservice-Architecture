using Microsoft.AspNetCore.Http;
using University.Domain.Attributes.Email;
using University.Domain.Attributes.Length;
using University.Domain.Attributes.Password;
using University.Domain.Attributes.PhoneNumber;
using University.Domain.Enums.Genders;

namespace University.Domain.Dtos.Students
{
    public class StudentCreateDto
    {
        [Length]
        public string FirstName { get; set; }
        [Length]
        public string LastName { get; set; }
        [Email]
        public string Email { get; set; }
        [Password]
        public string Password { get; set; }
        [Length]
        public string Address { get; set; }
        public IFormFile Image { get; set; }
        public string AddressTemporary { get; set; }
        public string Salt { get; set; }
        [PhoneNumber]
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public int GroupId { get; set; }
    }
}