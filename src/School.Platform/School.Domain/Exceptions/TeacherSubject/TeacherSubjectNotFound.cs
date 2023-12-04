namespace School.Domain.Exceptions.TeacherSubject
{
    public class TeacherSubjectNotFound : NotFoundException
    {
        public TeacherSubjectNotFound()
        {
            TitleMessage = "Teacher Subject Not Found !";
        }
    }
}