using System.ComponentModel.DataAnnotations;

namespace ThreatMap.Admin.ViewModels.Account
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Podaj email")]
        [EmailAddress(ErrorMessage = "Podaj poprawny adres email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Podaj hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}