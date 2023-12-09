using PublicTransport.Domain.Entities.Payments;
using PublicTransport.Domain.Enums.Roles;

namespace PublicTransport.Domain.Entities.Users
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<Payment> Payment { get; set; }
    }
}