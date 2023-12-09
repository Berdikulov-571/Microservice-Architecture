namespace PublicTransport.Domain.Dtos.Drivers
{
    public class DriverUpdateDto
    {
        public int Id { get; set; }
        public string DriveName { get; set; }
        public int LicenseNumber { get; set; }

        public int TransportId { get; set; }
    }
}