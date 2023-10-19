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

        public List<Auction> GetAllActive()
        {
            return _auctionPersistence.GetAllActive();
        }

        public List<Auction> GetAllByUserName(string userName)
        {
            return _auctionPersistence.GetAllByUserName(userName);
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
    }
}
