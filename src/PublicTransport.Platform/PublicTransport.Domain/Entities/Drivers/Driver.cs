using PublicTransport.Domain.Entities.Transports;
using System.ComponentModel.DataAnnotations.Schema;

namespace PublicTransport.Domain.Entities.Drivers
{
    public class Driver
    {
        public int Id { get; set; }
        public string DriveName { get; set; }
        public int LicenseNumber { get; set; }

        [ForeignKey(nameof(Transport))]
        public int TransportId { get; set; }
        public Transport Transport { get; set; }
    }
}