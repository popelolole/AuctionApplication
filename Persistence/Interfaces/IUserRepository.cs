using AuctionApplication.Areas.Identity.Data;

namespace AuctionApplication.Persistence.Interfaces
{
    public interface IUserRepository : IRepository<AuctionApplicationUser>
    {
        AuctionApplicationUser Get(string id);
    }
}
