using AuctionApplication.Areas.Identity.Data;

namespace AuctionApplication.Core.Interfaces
{
    public interface IUserPersistence
    {
        List<User> GetAll();
        User GetById(string id);
        void Delete(string id);
    }
}
