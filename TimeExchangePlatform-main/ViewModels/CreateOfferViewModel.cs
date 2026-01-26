using System.ComponentModel.DataAnnotations;
using TimeExchangePlatform.Models;

namespace TimeExchangePlatform.ViewModels
{
    public class CreateOfferViewModel
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = null!;
        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; } = null!;
        
        
    }
}
