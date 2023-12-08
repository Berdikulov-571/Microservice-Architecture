using Kadastr.Domain.Entities.Parcels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kadastr.Domain.Entities.LegalDescriptions
{
    // Huquqiy Tavfsifi
    public class LegalDescription : Auditable
    {
        public int LegalDescriptionID { get; set; }
        [ForeignKey(nameof(Parcel))]
        public int ParcelID { get; set; }
        public string DescriptionText { get; set; }

        public virtual Parcel Parcel { get; set; }
    }

}