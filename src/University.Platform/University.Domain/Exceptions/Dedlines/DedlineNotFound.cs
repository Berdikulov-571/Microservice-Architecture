namespace University.Domain.Exceptions.Dedlines
{
    public class DedlineNotFound : GlobalException
    {
        public DedlineNotFound()
        {
            TitleMessage = "Dedline Not Found !";
        }
    }
}