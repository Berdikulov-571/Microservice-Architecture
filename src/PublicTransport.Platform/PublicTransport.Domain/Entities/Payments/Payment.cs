using PublicTransport.Domain.Entities.Transports;
using PublicTransport.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace PublicTransport.Domain.Entities.Payments
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amaunt { get; set; }
        public DateTime PaymentDate { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [ForeignKey(nameof(Transport))]
        public int TransportId { get; set; }

        public User User { get; set; }
        public Transport Transport { get; set; }
    }
}