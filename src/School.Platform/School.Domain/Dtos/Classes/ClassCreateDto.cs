namespace School.Domain.Dtos.Classes
{
    public class ClassCreateDto
    {
        public string Name { get; set; }
        public int ClassTeacherId { get; set; }
        public int RoomNumber { get; set; }
    }
}
