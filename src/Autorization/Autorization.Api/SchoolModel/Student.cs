using Autorization.Api.Enums;
using Autorization.Api.UNiverModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autorization.Api.SchoolModel
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string ImagePath { get; set; }
    }
}