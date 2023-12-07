using Autorization.Api.Enums;
using System.ComponentModel.DataAnnotations;

namespace Autorization.Api.UNiverModels
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public string AddressTemporary { get; set; }
        public string PhoneNumber { get; set; }
        public string Salt { get; set; }
        public Gender Gender { get; set; }
        public Role Role { get; set; }
        public DateTime Birthdate { get; set; }
        public int GroupId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
    public enum Gender
    {
        Male = 1,
        Female,
    }
}
