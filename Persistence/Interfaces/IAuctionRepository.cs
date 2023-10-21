
namespace AuctionApplication.Persistence.Interfaces
{
    public interface IAuctionRepository : IRepository<AuctionDB>
    {
        IEnumerable<AuctionDB> GetAllActive(string userName);
        IEnumerable<AuctionDB> GetAllByUserName(string userName);
        IEnumerable<AuctionDB> GetAllActiveByBidUserName(string userName);
        IEnumerable<AuctionDB> GetAllWonByUserName(string userName);
        AuctionDB GetById(int id);
    }
}
