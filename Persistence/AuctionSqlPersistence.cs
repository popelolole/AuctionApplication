using System.Runtime.Intrinsics.Arm;
using AuctionApplication.Core;
using AuctionApplication.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuctionApplication.Persistence
{
    public class AuctionSqlPersistence : IAuctionPersistence
    {
        private AuctionDbContext _dbContext;

        public AuctionSqlPersistence(AuctionDbContext dbContext) 
        {
            _dbContext = dbContext; 
        }

        public List<Auction> GetAll()
        {
            var auctionDbs = _dbContext.AuctionDBs
                .Where(p => true)
                .Include(p => p.BidDBs)
                .ToList();

            List<Auction> result = new List<Auction>();
            foreach(AuctionDB adb in auctionDbs)
            {
                Auction auction = new Auction(
                    adb.Id,
                    adb.Name,
                    adb.UserName,
                    adb.StartingPrice,
                    adb.ClosingTime);
                result.Add(auction);
            }
            return result;
        }
    }
}
