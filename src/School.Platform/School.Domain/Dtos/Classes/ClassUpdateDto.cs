namespace School.Domain.Dtos.Classes
{
    public class ClassUpdateDto
    {
        public int ClassId { get; set; }
        public string Name { get; set; }
        public int ClassTeacherId { get; set; }
        public int RoomNumber { get; set; }
    }
}
