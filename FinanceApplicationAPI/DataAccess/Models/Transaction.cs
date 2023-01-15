using FinanceApplicationAPI.DataAccess.Models;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace FinanceApplicationAPI.Data.Models
{
    public class Transaction
    {
        public string? TransactionID { get; set; }
        public DateTime Date { get; set; }
        public bool FlowType { get; set; }
        public double Amount { get; set; }

        // TransactionName FK
        public string? TransactionNameID { get; set; }
        public TransactionName? TransactionName { get; set; }

        // TransactionType FK
        public string? TransactionTypeID { get; set; }
        public TransactionType? TransactionType { get; set; }

        // Account FK
        public string? AccountID { get; set; }
        public Account? Account { get; set; }


    }
}
