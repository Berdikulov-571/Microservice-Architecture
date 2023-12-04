namespace School.Domain.Exceptions.Task
{
    public class TaskNotFound : NotFoundException
    {
        public TaskNotFound()
        {
            TitleMessage = "Task Not Found !";
        }
    }
}
