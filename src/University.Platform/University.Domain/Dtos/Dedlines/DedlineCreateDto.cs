using Microsoft.AspNetCore.Http;

namespace University.Domain.Dtos.Dedlines
{
    public class DedlineCreateDto
    {
        public float MaxGrade { get; set; }
        public DateTime ExpiredDate { get; set; }
        public IFormFile FilePath { get; set; }
        public int CourseId { get; set; }
    }
}