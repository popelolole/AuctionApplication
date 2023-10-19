namespace AuctionApplication.Core.Interfaces
{
    public interface IAuctionService
    {
        List<Auction> GetAll();
        List<Auction> GetAllActive();
        List<Auction> GetAllByUserName(string userName);
        Auction GetById(int id);
        void Add(Auction auction);
        void Edit(int id, string userName);
        Boolean Place(Bid bid);
    }
}
