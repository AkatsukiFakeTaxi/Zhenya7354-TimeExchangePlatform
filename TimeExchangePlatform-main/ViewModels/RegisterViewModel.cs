using System.ComponentModel.DataAnnotations;

namespace TimeExchangePlatform.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(40, MinimumLength =8, ErrorMessage = "Password must be between {2} and {1} characters")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage ="Password doesnt match. ")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Confirm Password is requaired")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
