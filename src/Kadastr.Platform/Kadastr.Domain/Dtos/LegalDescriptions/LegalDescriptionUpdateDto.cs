using Kadastr.Domain.Entities.Parcels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kadastr.Domain.Dtos.LegalDescriptions
{
    public class LegalDescriptionUpdateDto
    {
        public int LegalDescriptionId { get; set; }
        public int ParcelID { get; set; }
        public string DescriptionText { get; set; }
    }

}