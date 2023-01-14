using FinanceApplicationAPI.DataAccess.Models;

namespace FinanceApplicationAPI.Data.Models
{
    public class TransactionModel
    {
        public string? TransactionID { get; set; }

        public DateTime Date { get; set; }
        public string? Description { get; set; }

        public bool TransactionType { get; set; }
        public string? Type { get; set; }

        public double Amount { get; set; }

        public string? UserID { get; set; }
        public UserModel? User { get; set; }

    }
}
