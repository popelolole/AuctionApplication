using System.ComponentModel.DataAnnotations;

namespace AuctionApplication.Persistence
{
    public class AuctionDB
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        [MaxLength(128)]
        public string UserName { get; set; }

        [Required]
        public int StartingPrice { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ClosingTime { get; set; }
        
        public IEnumerable<BidDB> BidDBs { get; set; } = new List<BidDB>();
    }
}
