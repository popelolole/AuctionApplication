namespace AuctionApplication.Core.Interfaces
{
    public interface IAuctionPersistence
    {
        List<Auction> GetAll();

        List<Auction> GetAllByUserName(string userName);

        public Auction GetById(int id);

        void Add(Auction auction);
    }
}
