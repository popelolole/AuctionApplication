using System.Runtime.Intrinsics.Arm;
using AuctionApplication.Core;
using AuctionApplication.Core.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuctionApplication.Persistence
{
    public class AuctionSqlPersistence : IAuctionPersistence
    {
        private AuctionDbContext _dbContext;
        private IMapper _mapper;

        public AuctionSqlPersistence(AuctionDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
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
                /*Auction auction = new Auction(
                    adb.Id,
                    adb.Name,
                    adb.UserName,
                    adb.StartingPrice,
                    adb.ClosingTime);
                result.Add(auction);*/

                Auction auction = _mapper.Map<Auction>(adb);
                result.Add(auction);
            }
            return result;
        }

        public Auction GetById(int id)
        {
            var auctionDb = _dbContext.AuctionDBs
                .Include(p => p.BidDBs)
                .Where(p => p.Id == id)
                .SingleOrDefault();

            Auction auction = _mapper.Map<Auction>(auctionDb);
            foreach(BidDB bdb in auctionDb.BidDBs)
            {
                auction.AddBid(_mapper.Map<Bid>(bdb));
            }
            return auction;
        }

        public void Add(Auction auction)
        {
            AuctionDB adb = _mapper.Map<AuctionDB>(auction);
            _dbContext.AuctionDBs.Add(adb);
            _dbContext.SaveChanges();
        }
    }
}
