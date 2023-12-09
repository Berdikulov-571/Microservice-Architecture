namespace PublicTransport.Domain.Dtos.Drivers
{
    public class DriverCreateDto
    {
        public string DriveName { get; set; }
        public int LicenseNumber { get; set; }

        public int TransportId { get; set; }
    }
}
