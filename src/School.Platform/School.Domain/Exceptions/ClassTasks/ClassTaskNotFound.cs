namespace School.Domain.Exceptions.ClassTasks
{
    public class ClassTaskNotFound : NotFoundException
    {
        public ClassTaskNotFound()
        {
            TitleMessage = "ClassTask Not Found !";
        }
    }
}
