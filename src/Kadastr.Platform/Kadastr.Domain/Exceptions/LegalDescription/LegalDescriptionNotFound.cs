namespace Kadastr.Domain.Exceptions.LegalDescription
{
    public class LegalDescriptionNotFound : GlobalException
    {
        public LegalDescriptionNotFound()
        {
            TitleMessage = "Legal Description Not Found !";
        }
    }
}