using PublicTransport.Domain.Entities.Schedules;

namespace PublicTransport.Domain.Entities.Routes
{
    public class Route
    {
        public int Id { get; set; }
        public string RouteName { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}