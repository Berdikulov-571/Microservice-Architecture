namespace University.Domain.Exceptions.Files
{
    public class FileNotValid : GlobalException
    {
        public FileNotValid()
        {
            TitleMessage = "File Not Valid";
        }
    }
}