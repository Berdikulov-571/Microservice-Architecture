namespace School.Domain.Exceptions.Admins
{
    public class AdminNotFound : NotFoundException
    {
        public AdminNotFound()
        {
            TitleMessage = "Admin Not Found !";
        }
    }
}
