using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApplication.ViewModels
{
    public class CreateAuctionVM
    {
        [Required]
        [StringLength(128, ErrorMessage = "Max length 128 characters")]
        public string Name { get; set; }

        [StringLength(255, ErrorMessage = "Max length 255 characters")]
        public string? Description { get; set; }

        [Required]
        public int StartingPrice { get; set; }

        [Required]
        [BindProperty]
        [DataType(DataType.DateTime)]
        public DateTime ClosingTime { get; set; }
        
    }
}
