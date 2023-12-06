namespace University.Domain.Exceptions.Files
{
    public class FileNotFound : GlobalException
    {
        public FileNotFound()
        {
            TitleMessage = "File Not Found !";
        }
    }
}