namespace University.Domain.Exceptions.Groups
{
    public class GroupNotFound : GlobalException
    {
        public GroupNotFound()
        {
            TitleMessage = "Group Not Found";
        }
    }
}