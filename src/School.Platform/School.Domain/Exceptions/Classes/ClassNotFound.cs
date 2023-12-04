namespace School.Domain.Exceptions.Classes
{
    public class ClassNotFound : NotFoundException
    {
        public ClassNotFound()
        {
            TitleMessage = "Class Not Found !";
        }
    }
}
