using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Repository.Models
{
    [Table("Transaction")]
    public partial class Transaction
    {
        [Key]
        [Column("TransactionID")]
        public int TransactionId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? FromAccount { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? ToAccount { get; set; }
        public DateTime? TransactionTime { get; set; }
        [Column(TypeName = "money")]
        public decimal? AmountDebited { get; set; }
        [Column(TypeName = "money")]
        public decimal? FromAccountBalance { get; set; }
        [Column(TypeName = "money")]
        public decimal? ToAccountBalance { get; set; }
    }
}
