using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionApplication.Persistence
{
    public class BidDB
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string UserName { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [ForeignKey("AuctionId")]
        public AuctionDB AuctionDB { get; set; }
    }
}
