namespace Kadastr.Domain.Dtos.Parcels
{
    public class ParcelCreateDto
    {
        public int OwnerID { get; set; }
        public string ParcelNumber { get; set; }
        public decimal Area { get; set; }
    }
}
