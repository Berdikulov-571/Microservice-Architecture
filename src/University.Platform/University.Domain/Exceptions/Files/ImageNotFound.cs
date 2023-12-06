namespace University.Domain.Exceptions.Files
{
    public class ImageNotFound : GlobalException
    {
        public ImageNotFound()
        {
            TitleMessage = "Image Not Found !";
        }
    }
}