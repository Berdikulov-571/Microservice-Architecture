namespace Kadastr.Domain.Exceptions.LandUses
{
    public class LandUseNotFound : GlobalException
    {
        public LandUseNotFound()
        {
            TitleMessage = "Land Use Not Found !";
        }
    }
}