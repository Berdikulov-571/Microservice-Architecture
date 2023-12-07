namespace Autorization.Api
{
    public class UserNotFound : Exception
    {
        public string Title { get; set; }
        public UserNotFound()
        {
            Title = "User Not Found !";
        }
    }
}