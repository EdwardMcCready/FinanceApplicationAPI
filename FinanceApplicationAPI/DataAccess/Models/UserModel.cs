using FinanceApplicationAPI.Data.Models;

namespace FinanceApplicationAPI.DataAccess.Models
{
    public class UserModel
    {
        public string? UserID { get; set;  }
        public string? UserName { get; set; }

        public ICollection<TransactionModel>? Transactions { get; set; }
    }
}
