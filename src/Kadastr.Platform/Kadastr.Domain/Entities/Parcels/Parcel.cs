using Kadastr.Domain.Entities.Owners;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kadastr.Domain.Entities.Parcels
{
    public class Parcel : Auditable
    {
        [Key]
        public int ParcelID { get; set; }
        [ForeignKey(nameof(Owner))]
        public int OwnerID { get; set; }
        public string ParcelNumber { get; set; }
        public decimal Area { get; set; }

        public virtual Owner Owner { get; set; }
    }
}
