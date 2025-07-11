﻿using System.ComponentModel.DataAnnotations;

namespace BankingApp.Models.ViewModels
{
    public class AccountViewModels
    {
        public int AccountID { get; set; }


        [Required(ErrorMessage = "An account name is required")]
        public string? AccountName { get; set; }
        public decimal? Balance { get; set; } 

        public List<AccountViewModels> ? Accounts { get; set; }
    }
}
