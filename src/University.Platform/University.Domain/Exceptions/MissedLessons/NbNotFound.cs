namespace University.Domain.Exceptions.MissedLessons
{
    public class NbNotFound : GlobalException
    {
        public NbNotFound()
        {
            TitleMessage = "Nb Not Found !";
        }
    }
}