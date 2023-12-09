namespace PublicTransport.Domain.Dtos.Routes
{
    public class RouteCreateDto
    {
        public string RouteName { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
    }
}