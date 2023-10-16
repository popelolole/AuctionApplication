using AuctionApplication.Core;

namespace AuctionApplication.ViewModels
{
    public class BidVM
    {
        public string UserName { get; set; }
        public int Price { get; set; }
        public DateTime CreatedDate { get; set; }

        public static BidVM FromBid(Bid bid)
        {
            return new BidVM
            {
                UserName = bid.UserName,
                Price = bid.Price,
                CreatedDate = bid.CreatedDate
            };
        }
    }
}
