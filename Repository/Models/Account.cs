using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Repository.Models
{
    [Table("Account")]
    public partial class Account
    {
        [Key]
        [Column("AccountID")]
        public int AccountId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Name { get; set; }
        [Column(TypeName = "money")]
        public decimal? Balance { get; set; }
    }
}
