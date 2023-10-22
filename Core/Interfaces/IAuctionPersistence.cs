namespace AuctionApplication.Core.Interfaces
{
    public interface IAuctionPersistence
    {
        List<Auction> GetAll();

        List<Auction> GetAllActive(string userName);

        List<Auction> GetAllByUserName(string userName);

        List<Auction> GetAllActiveByBidUserName(string userName);

        List<Auction> GetAllWonByUserName(string userName);

        public Auction GetById(int id);

        void Add(Auction auction);

        void Edit(int id, string description);

        void Place(Bid bid);

        void RemoveById(int id);
    }
}
