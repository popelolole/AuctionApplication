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
                .Include(p => p.BidDBs.OrderByDescending(b => b.Price))
                .OrderBy(p => p.ClosingTime)
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

        public List<Auction> GetAllActive()
        {
            var auctionDbs = _dbContext.AuctionDBs
                .Where(p => p.ClosingTime >= DateTime.Now)
                .Include(p => p.BidDBs.OrderByDescending(b => b.Price))
                .OrderBy(p => p.ClosingTime)
                .ToList();

            List<Auction> result = new List<Auction>();
            foreach (AuctionDB adb in auctionDbs)
            {
                Auction auction = _mapper.Map<Auction>(adb);
                result.Add(auction);
            }
            return result;
        }

        public List<Auction> GetAllByUserName(string userName)
        {
            var auctionDbs = _dbContext.AuctionDBs
                .Where(p => p.UserName.Equals(userName))
                .Include(p => p.BidDBs.OrderByDescending(b => b.Price))
                .OrderBy(p => p.ClosingTime)
                .ToList();

            List<Auction> result = new List<Auction>();
            foreach (AuctionDB adb in auctionDbs)
            {
                Auction auction = _mapper.Map<Auction>(adb);
                result.Add(auction);
            }
            return result;
        }

        public Auction GetById(int id)
        {
            var auctionDb = _dbContext.AuctionDBs
                .Include(p => p.BidDBs.OrderByDescending(b => b.Price))
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

        public void Edit(int id, string description)
        {
            var adb = _dbContext.AuctionDBs
                .Find(id);
            adb.Description = description;
            _dbContext.SaveChanges();
        }

        public void Place(Bid bid)
        {
            BidDB bdb = _mapper.Map<BidDB>(bid);
            _dbContext.BidDBs.Add(bdb);
            _dbContext.SaveChanges();
        }
    }
}
