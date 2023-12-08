using Microsoft.AspNetCore.Http;
using School.Domain.Attributes.Email;
using School.Domain.Attributes.Length;
using School.Domain.Attributes.Password;
using School.Domain.Attributes.PhoneNumber;
using School.Domain.Enums.GenderEnum;
using School.Domain.Enums.RoleEnum;

namespace School.Domain.Dtos.Students
{
    public class StudentCreateDto
    {
        [Length]
        public string UserName { get; set; }
        [Length]
        public string FirstName { get; set; }
        [Length]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        [PhoneNumber]
        public string PhoneNumber { get; set; }
        [Length]
        public string Address { get; set; }
        [Password]
        public string Password { get; set; }
        [Email]
        public string Email { get; set; }
        public IFormFile Image { get; set; }
        public int ClassId { get; set; }
    }
}