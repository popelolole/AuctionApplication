using System.ComponentModel.DataAnnotations;

namespace AuctionApplication.ViewModels
{
    public class EditAuctionVM
    {
        [Required]
        [StringLength(255, ErrorMessage = "Max length 255 characters")]
        public string? Description { get; set; }
    }
}
