using Kadastr.Domain.Entities.Parcels;
using System.ComponentModel.DataAnnotations;

namespace Kadastr.Domain.Dtos.Owners
{
    public class OwnerCreateDto
    {
        public string OwnerName { get; set; }
        public string ContactInfo { get; set; }
    }
}