namespace School.Domain.Dtos.TeacherSubjectRelation
{
    public class TeacherSubjectUpdateDto
    {
        public int TeacherSubjectId { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
    }
}
