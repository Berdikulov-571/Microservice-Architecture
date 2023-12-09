using PublicTransport.Domain.Entities.Routes;
using PublicTransport.Domain.Entities.Transports;
using System.ComponentModel.DataAnnotations.Schema;

namespace PublicTransport.Domain.Entities.Schedules
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public int TransportId { get; set; }

        [ForeignKey(nameof(Route))]
        public int RouteId { get; set; }

        public Route Route { get; set; }
        public Transport Transport { get; set; }
    }
}