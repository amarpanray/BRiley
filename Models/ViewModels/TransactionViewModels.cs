namespace BankingApp.Models.ViewModels
{
    public class TransactionViewModels
    {
        public int TransactionID { get; set; }
        public string? FromAccount { get; set; }
        public string? ToAccount { get; set; }
        public DateTime? TransactionTime { get; set; }

        public decimal? TransferAmount { get; set; }
        public decimal? BalanceFrom { get; set; }
        public decimal? BalanceTo { get; set; }

        public List<TransactionViewModels> Transactions { get; set; }
    }
}
