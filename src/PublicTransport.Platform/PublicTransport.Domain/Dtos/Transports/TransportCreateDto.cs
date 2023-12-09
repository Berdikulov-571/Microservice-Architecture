namespace PublicTransport.Domain.Dtos.Transports
{
    public class TransportCreateDto
    {
        public string TransportName { get; set; }
        public string TransportType { get; set; }
        public int Capacity { get; set; }
    }
}