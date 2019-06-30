using System.ComponentModel.DataAnnotations;

namespace ExploreCalifornia57.Models.Account
{
    public class LoginViewModel
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

        [Display(Name = "Remember Me")]
        public bool RememberMe57 { get; set; }
    }

}