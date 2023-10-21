using AuctionApplication.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuctionApplication.Persistence.Repositories
{
    public class BidRepository : Repository<BidDB>, IBidRepository
    {
        public BidRepository(AuctionDbContext context) : base(context)
        {
        }

        public AuctionDbContext AuctionDbContext
        {
            get { return Context as AuctionDbContext; }
        }
    }
}
