using School.Domain.Enums.RoleEnum;

namespace School.Domain.Dtos.Admins
{
    public class AdminCreateDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
