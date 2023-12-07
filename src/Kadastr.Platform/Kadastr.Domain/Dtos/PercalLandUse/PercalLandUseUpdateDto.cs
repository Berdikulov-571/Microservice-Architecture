namespace Kadastr.Domain.Dtos.PercalLandUse
{
    public class PercalLandUseUpdateDto
    {
        public int ParcelLandUseID { get; set; }

        public int ParcelID { get; set; }
        public int LandUseID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}