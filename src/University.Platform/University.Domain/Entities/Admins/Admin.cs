using System.ComponentModel.DataAnnotations;
using University.Domain.Common.BaseEntities;
using University.Domain.Enums.Roles;

namespace University.Domain.Entities.Admins
{
    public class Admin : Auditable
    {
        [Key]
        public int AdminId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string ImagePath { get; set; }
    }
}
