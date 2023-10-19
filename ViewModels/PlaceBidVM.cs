using System.ComponentModel.DataAnnotations;

namespace AuctionApplication.ViewModels
{
    public class PlaceBidVM
    {
        [Required]
        public int Price { get; set; }
    }
}
