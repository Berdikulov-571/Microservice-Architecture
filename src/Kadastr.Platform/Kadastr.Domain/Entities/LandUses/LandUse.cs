using System.ComponentModel.DataAnnotations;

namespace Kadastr.Domain.Entities.LandUses
{
    // Yerdan Foydalanish
    public class LandUse : Auditable
    {
        [Key]
        public int LandUseID { get; set; }
        // Yerdan foydalanish turi
        public string LandUseType { get; set; }
    }
}