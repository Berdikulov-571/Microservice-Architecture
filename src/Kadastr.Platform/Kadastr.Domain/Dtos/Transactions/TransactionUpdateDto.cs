namespace Kadastr.Domain.Dtos.Transactions
{
    public class TransactionUpdateDto
    {
        public int TransactionID { get; set; }
        public int ParcelID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
    }
}
