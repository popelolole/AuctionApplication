using AuctionApplication.Core.Interfaces;

namespace AuctionApplication.Core
{
    public class MockAuctionService : IAuctionService
    {
        public List<Auction> GetAll()
        {
            Auction a1 = new Auction(1, "Tims mamma", "pelle", 1, new DateTime(2023, 10, 16, 12, 0, 0));
            Auction a2 = new Auction(2, "Tims pappa", "elias", 200, new DateTime(2023, 10, 16, 16, 0, 0));
            a1.AddBid(new Bid(3, "elias", 1));
            a1.AddBid(new Bid(4, "peter", 250));
            List<Auction> auctions = new();
            auctions.Add(a1);
            auctions.Add(a2);
            return auctions;
        }
    }
}
