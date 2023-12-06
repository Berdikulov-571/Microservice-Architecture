namespace University.Domain.Exceptions.Admins
{
    public class AdminNotFound : GlobalException
    {
        public AdminNotFound()
        {
            TitleMessage = "Admin Not Found !";
        }
    }
}