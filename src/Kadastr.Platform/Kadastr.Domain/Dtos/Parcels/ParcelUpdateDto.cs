namespace Kadastr.Domain.Dtos.Parcels
{
    public class ParcelUpdateDto
    {
        public int ParcelID { get; set; }
        public int OwnerID { get; set; }
        public string ParcelNumber { get; set; }
        public decimal Area { get; set; }
    }
}
