namespace University.Domain.Exceptions.Files
{
    public class ImageNotValid : GlobalException
    {
        public ImageNotValid()
        {
            TitleMessage = "Image Not Valid !";
        }
    }
}