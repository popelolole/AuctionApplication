namespace AuctionApplication.Core.Interfaces
{
    public interface IAuctionService
    {
        List<Auction> GetAll();
        List<Auction> GetAllActive(string userName);
        List<Auction> GetAllByUserName(string userName);
        List<Auction> GetAllActiveByBidUserName(string userName);
        
        List<Auction> GetAllWonByUserName(string userName);
        Auction GetById(int id);
        void Add(Auction auction);
        void Edit(int id, string userName);
        ValidationResult Place(Bid bid);
    }
}
