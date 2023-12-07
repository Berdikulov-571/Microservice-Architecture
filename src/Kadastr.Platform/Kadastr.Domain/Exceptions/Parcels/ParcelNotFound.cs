namespace Kadastr.Domain.Exceptions.Parcels
{
    public class ParcelNotFound : GlobalException
    {
        public ParcelNotFound()
        {
            TitleMessage = "Parcel Not Found !";
        }
    }
}