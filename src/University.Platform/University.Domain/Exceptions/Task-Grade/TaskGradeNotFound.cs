namespace University.Domain.Exceptions.Task_Grade
{
    public class TaskGradeNotFound : GlobalException
    {
        public TaskGradeNotFound()
        {
            TitleMessage = "Task Grade Not Found !";
        }
    }
}