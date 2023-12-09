namespace PublicTransport.Domain.Dtos.Payments
{
    public class PaymentCreateDto
    {
        public decimal Amaunt { get; set; }
        public int UserId { get; set; }
        public int TransportId { get; set; }
    }
}
