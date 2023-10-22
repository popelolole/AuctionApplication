using AuctionApplication.Areas.Identity.Data;
using AuctionApplication.Core.Interfaces;

namespace AuctionApplication.Core
{
    public class UserService : IUserService
    {
        private IUserPersistence _userPersistence;

        public UserService(IUserPersistence userPersistence)
        {
            _userPersistence = userPersistence;
        }

        public List<User> GetAll()
        {
            return _userPersistence.GetAll();
        }

        public User GetById(string id)
        {
            return _userPersistence.GetById(id);
        }

        public void Delete(string id)
        {
            _userPersistence.Delete(id);
        }

    }
}
