namespace FinanceApplicationAPI.Models
{
    public class TransactionDataModel
    {
        public DateTime DateTime { get; set; }
        public int Year { get; set; }
        public string? Description { get; set; }

        public bool Type { get; set; }
        public double Amount { get; set; }
    }
}
