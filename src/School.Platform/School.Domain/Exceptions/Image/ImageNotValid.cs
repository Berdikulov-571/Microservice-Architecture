namespace School.Domain.Exceptions.Image
{
    public class ImageNotValid : NotFoundException
    {
        public ImageNotValid()
        {
            TitleMessage = "Image Not Valid !";
        }
    }
}