using Microsoft.AspNetCore.Http;
using School.Domain.Attributes.Email;
using School.Domain.Attributes.Length;
using School.Domain.Attributes.Password;
using School.Domain.Enums.GenderEnum;
using System.ComponentModel.DataAnnotations;

namespace School.Domain.Dtos.Students
{
    public class StudentUpdateDto
    {
        public int StudentId { get; set; }
        [Length]
        public string UserName { get; set; }
        [Length]
        public string FirstName { get; set; }
        [Length]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        [Password]
        public string Password { get; set; }
        [Email]
        public string Email { get; set; }
        public IFormFile? Image { get; set; }
        public int ClassId { get; set; }
    }
}
