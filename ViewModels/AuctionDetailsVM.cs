using AuctionApplication.Core;

namespace AuctionApplication.ViewModels
{
    public class AuctionDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public int StartingPrice { get; set; }
        public DateTime ClosingTime { get; set; }
        private List<BidVM> _bids = new List<BidVM>();
        public IEnumerable<BidVM> Bids => _bids;

        public static AuctionDetailsVM FromAuction(Auction auction)
        {
            AuctionDetailsVM auctionVM = new AuctionDetailsVM()
            {
                Id = auction.Id,
                Name = auction.Name,
                Description = auction.Description,
                UserName = auction.UserName,
                StartingPrice = auction.StartingPrice,
                ClosingTime = auction.ClosingTime
            };
            foreach (var bid in auction.Bids)
            {
                auctionVM.AddBid(BidVM.FromBid(bid));
            }
            return auctionVM;
        }

        public void AddBid(BidVM newBid)
        {
            _bids.Add(newBid);
        }
    }
}
