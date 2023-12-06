using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using University.Domain.Common.BaseEntities;
using University.Domain.Entities.Groups;
using University.Domain.Enums.Genders;
using University.Domain.Enums.Roles;

namespace University.Domain.Entities.Students
{
    public class Student : Auditable
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
        [ForeignKey(nameof(Group))]
        public int GroupId { get; set; }
        public Group? Group { get; set; }
    }
}