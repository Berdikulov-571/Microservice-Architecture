namespace Kadastr.Domain.Exceptions.Owners
{
    public class OwnerNotFound : GlobalException
    {
        public OwnerNotFound()
        {
            TitleMessage = "Owner Not Found !";
        }
    }
}