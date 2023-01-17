namespace FinanceApplicationAPI.DataAccess.Models
{
    public class TransactionName
    {
        public string? TransactionNameID { get; set; }
        public string? Name { get; set; }

        public ICollection<Transaction>? Transactions { get; set; }
    }
}
