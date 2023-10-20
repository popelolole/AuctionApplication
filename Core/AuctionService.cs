using AuctionApplication.Core.Interfaces;


namespace AuctionApplication.Core
{
    public class AuctionService : IAuctionService
    {
        private IAuctionPersistence _auctionPersistence;

        public AuctionService(IAuctionPersistence auctionPersistence)
        {
            _auctionPersistence = auctionPersistence;
        }

        public List<Auction> GetAll()
        {
            return _auctionPersistence.GetAll();
        }

        public List<Auction> GetAllActive(string userName)
        {
            return _auctionPersistence.GetAllActive(userName);
        }

        public List<Auction> GetAllByUserName(string userName)
        {
            return _auctionPersistence.GetAllByUserName(userName);
        }

        public List<Auction> GetAllActiveByBidUserName(string userName)
        {
            return _auctionPersistence.GetAllActiveByBidUserName(userName);
        }

        public Auction GetById(int id)
        {
            return _auctionPersistence.GetById(id);
        }

        public void Add(Auction auction)
        {
            if (auction == null || auction.Id != 0) throw new InvalidDataException();
            _auctionPersistence.Add(auction);
        }

        public void Edit(int id, string description)
        {
            _auctionPersistence.Edit(id, description);
        }

        public Boolean Place(Bid bid)
        {
            Auction auction = GetById(bid.AuctionId);
            if (bid == null || bid.Id != 0 || bid.Price < 0) throw new InvalidDataException();

            if (!auction.Bids.Any())
            {
                if (bid.Price < auction.StartingPrice) return false;
            }
            else
            {
                if (bid.Price <= auction.Bids.First().Price) return false;
            }

            _auctionPersistence.Place(bid);
            return true;
        }
    }
}
