using Kadastr.Domain.Entities.Parcels;
using System.ComponentModel.DataAnnotations;

namespace Kadastr.Domain.Entities.Owners
{
    public class Owner : Auditable
    {
        [Key]
        public int OwnerID { get; set; }
        public string OwnerName { get; set; }
        public string ContactInfo { get; set; }

        public virtual ICollection<Parcel> Parcels { get; set; }
    }
}