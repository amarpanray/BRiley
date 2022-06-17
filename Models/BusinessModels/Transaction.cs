namespace BankingApp.Models.BusinessModels
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public string? FromAccount { get; set; }
        public string? ToAccount { get; set; } 
        public DateTime TransactionTime { get; set; }

        public double TransferAmount { get; set; }
        public double BalanceFrom { get; set; }
        public double BalanceTo { get; set; }
    }
}
