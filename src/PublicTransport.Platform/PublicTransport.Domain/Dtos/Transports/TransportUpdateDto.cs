namespace PublicTransport.Domain.Dtos.Transports
{
    public class TransportUpdateDto
    {
        public int Id { get; set; }
        public string TransportName { get; set; }
        public string TransportType { get; set; }
        public int Capacity { get; set; }
    }
}