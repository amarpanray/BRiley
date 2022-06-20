using System.ComponentModel.DataAnnotations;

namespace BankingApp.Models.ViewModels
{
    public class TransferViewModels
    {
        [Required]
        public int FromAccountId { get; set; }


        [Required]
        public int ToAccountId { get; set; }
        public string? FromAccount { get; set; }
        public string? ToAccount { get; set; }
        public DateTime TransactionTime { get; set; }
        public decimal? TransferAmount { get; set; }
        public decimal? FromBalance { get; set; }

        public decimal? ToBalance { get; set; }
        public List<TransferViewModels>? FromAccounts { get; set; }
        public List<TransferViewModels>? ToAccounts { get; set; }

    }
}
