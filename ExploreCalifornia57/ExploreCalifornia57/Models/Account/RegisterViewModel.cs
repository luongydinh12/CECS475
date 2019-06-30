using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia57.Models.Account
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress, MaxLength(500)]
        [Display(Name = "Email Address")]
        public string EmailAddress57 { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password57 { get; set; }

        [Compare("Password57", ErrorMessage = "Passwords must match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword57 { get; set; }
    }
}
