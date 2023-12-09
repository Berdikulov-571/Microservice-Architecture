namespace PublicTransport.Domain.Dtos.Schedules
{
    public class ScheduleCreateDto
    {
        public int TransportId { get; set; }

        public int RouteId { get; set; }
    }
}