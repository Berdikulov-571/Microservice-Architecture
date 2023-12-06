namespace University.Domain.Common.BaseEntities
{
    public class Auditable
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}