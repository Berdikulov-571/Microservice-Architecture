using Kadastr.Domain.Entities.LandUses;
using Kadastr.Domain.Entities.Parcels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kadastr.Domain.Entities.PercalLandUses
{
    public class PercalLandUse : Auditable
    {
        [Key]
        public int ParcelLandUseID { get; set; }

        [ForeignKey(nameof(Parcel))]
        public int ParcelID { get; set; }
        [ForeignKey(nameof(LandUse))]
        public int LandUseID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Parcel Parcel { get; set; }
        public virtual LandUse LandUse { get; set; }
    }
}