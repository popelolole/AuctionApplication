using AuctionApplication.Persistence.Interfaces;
using AuctionApplication.Persistence.Repositories;

namespace AuctionApplication.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AuctionDbContext _dbContext;
        
        public IAuctionRepository Auctions { get; private set; }
        public IBidRepository Bids { get; private set; }

        public UnitOfWork(AuctionDbContext dbContext, IAuctionRepository auctions, IBidRepository bids)
        {
            _dbContext = dbContext;
            Auctions = auctions;
            Bids = bids;
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
