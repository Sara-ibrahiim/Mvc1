using System.ComponentModel.DataAnnotations;

namespace Demo.PL.Models
{
    public class ResetPasswordViewModel
    {
        [Required]
        [StringLength(6, MinimumLength = 6)]

        public string Password { get; set; }
        [Required]
        [StringLength(6, MinimumLength = 6)]
        [Compare(nameof(Password), ErrorMessage = " Password Mismatch")]

        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
        public string Token { get; set; }
    }
}
