
namespace FinanceApplicationAPI.DataAccess.Models
{
    public class Account
    {
        public string? AccountID { get; set;  }
        public string? AccountName { get; set; }

        public ICollection<Transaction>? Transactions { get; set; }
    }
}
