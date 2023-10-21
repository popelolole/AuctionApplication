using System.Linq.Expressions;
using AuctionApplication.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuctionApplication.Persistence.Repositories
{
    public class AuctionRepository : Repository<AuctionDB>, IAuctionRepository
    {
        public AuctionRepository(AuctionDbContext context) : base(context)
        {
        }

        public IEnumerable<AuctionDB> GetAllActive(string userName)
        {
            return AuctionDbContext.AuctionDBs
                .Where(p => p.ClosingTime >= DateTime.Now && p.UserName != userName)
                .Include(p => p.BidDBs.OrderByDescending(b => b.Price))
                .OrderBy(p => p.ClosingTime)
                .ToList();
        }

        public IEnumerable<AuctionDB> GetAllByUserName(string userName)
        {
            return AuctionDbContext.AuctionDBs
                .Where(p => p.UserName.Equals(userName))
                .Include(p => p.BidDBs.OrderByDescending(b => b.Price))
                .OrderBy(p => p.ClosingTime)
                .ToList();
        }

        public IEnumerable<AuctionDB> GetAllActiveByBidUserName(string userName)
        {
            return AuctionDbContext.AuctionDBs
                .Where(p => p.ClosingTime >= DateTime.Now
                    && p.BidDBs.Any(b => b.UserName.Equals(userName)))
                .Include(p => p.BidDBs.OrderByDescending(b => b.Price))
                .OrderBy(p => p.ClosingTime)
                .ToList();
        }

        public IEnumerable<AuctionDB> GetAllWonByUserName(string userName)
        {
            return AuctionDbContext.AuctionDBs
                .Include(p => p.BidDBs.OrderByDescending(b => b.Price))
                .Where(p => p.ClosingTime < DateTime.Now
                    && p.BidDBs.First().UserName.Equals(userName))
                .OrderBy(p => p.ClosingTime)
                .ToList();
        }

        public AuctionDB GetById(int id)
        {
            return AuctionDbContext.AuctionDBs
                .Include(p => p.BidDBs.OrderByDescending(b => b.Price))
                .Where(p => p.Id == id)
                .SingleOrDefault();
        }

        public AuctionDbContext AuctionDbContext
        {
            get { return Context as AuctionDbContext; }
        }
    }
}
