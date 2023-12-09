namespace PublicTransport.Domain.Dtos.Routes
{
    public class RouteUpdateDto
    {
        public int Id { get; set; }
        public string RouteName { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
    }
}