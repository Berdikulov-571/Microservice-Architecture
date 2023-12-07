using System.ComponentModel.DataAnnotations;

namespace Kadastr.Domain.Entities.LandUses
{
    public class LandUse : Auditable
    {
        [Key]
        public int LandUseID { get; set; }
        public string LandUseType { get; set; }
    }
}