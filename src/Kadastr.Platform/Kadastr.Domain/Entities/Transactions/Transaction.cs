using Kadastr.Domain.Entities.Parcels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kadastr.Domain.Entities.Transactions
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        [ForeignKey(nameof(Parcel))]
        public int ParcelID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }

        public virtual Parcel Parcel { get; set; }
    }
}
