namespace FinanceApplicationAPI.DataAccess.Models
{
    public class TransactionType
    {
        public string? TransactionTypeID { get; set; }
        public string? Type { get; set; }

        public ICollection<Transaction>? Transactions { get; set; }
    }
}
