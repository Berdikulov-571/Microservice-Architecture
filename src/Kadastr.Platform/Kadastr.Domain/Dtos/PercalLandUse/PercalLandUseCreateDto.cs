namespace Kadastr.Domain.Dtos.PercalLandUse
{
    public class PercalLandUseCreateDto
    {
        public int ParcelID { get; set; }
        public int LandUseID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}