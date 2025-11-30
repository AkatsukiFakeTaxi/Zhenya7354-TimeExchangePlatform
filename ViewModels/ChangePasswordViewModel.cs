using System.ComponentModel.DataAnnotations;

namespace TimeExchangePlatform.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "New Password")]
        [Required(ErrorMessage = "New Password is required.")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "New Password must be between {1} and {0} characters")]
        [DataType(DataType.Password)]
        [Compare("ConfirmNewPassword", ErrorMessage = "New Password doesnt match. ")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm Password is requaired")]
        [Display(Name = "Confirm New Password")]
        public string ConfirmNewPassword { get; set; }
    }
}
