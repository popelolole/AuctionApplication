using AuctionApplication.Data;
using AuctionApplication.Persistence.Interfaces;

namespace AuctionApplication.Persistence
{
    public class UserUnitOfWork : IUserUnitOfWork
    {
        private readonly AuctionApplicationIdentityContext _dbContext;

        public IUserRepository Users { get; private set; }

        public UserUnitOfWork(AuctionApplicationIdentityContext dbContext, IUserRepository users)
        {
            _dbContext = dbContext;
            Users = users;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
