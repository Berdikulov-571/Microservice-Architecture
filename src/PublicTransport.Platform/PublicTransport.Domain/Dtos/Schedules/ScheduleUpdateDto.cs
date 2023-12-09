namespace PublicTransport.Domain.Dtos.Schedules
{
    public class ScheduleUpdateDto
    {
        public int Id { get; set; }
        public int TransportId { get; set; }

        public int RouteId { get; set; }
    }
}