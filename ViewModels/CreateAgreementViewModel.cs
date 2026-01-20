using System.ComponentModel.DataAnnotations;

namespace TimeExchangePlatform.ViewModels
{
    public class CreateAgreementViewModel
    {
        
        public int OfferId { get; set; }
        [Required(ErrorMessage = "Hours are required.")]
        [Range(1, 10, ErrorMessage = "Hours must be between 1 and 10.")]
        public int Hours { get; set; }
    }
}
