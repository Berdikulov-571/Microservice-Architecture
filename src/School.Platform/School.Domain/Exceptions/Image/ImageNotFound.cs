namespace School.Domain.Exceptions.Image
{
    public class ImageNotFound : NotFoundException
    {
        public ImageNotFound()
        {
            TitleMessage = "Image Not Found !";
        }
    }
}