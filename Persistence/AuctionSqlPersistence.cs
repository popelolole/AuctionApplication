using System.Runtime.Intrinsics.Arm;
using AuctionApplication.Core;
using AuctionApplication.Core.Interfaces;
using AuctionApplication.Persistence.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuctionApplication.Persistence    
{
    public class AuctionSqlPersistence : IAuctionPersistence
    {
        private IMapper _mapper;
        private IAuctionUnitOfWork _unitOfWork;

        public AuctionSqlPersistence(IAuctionUnitOfWork unitOfWork, IMapper mapper) 
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public List<Auction> GetAll()
        {
            var auctionDbs = _unitOfWork.Auctions.GetAll();

            List<Auction> result = new List<Auction>();
            foreach(AuctionDB adb in auctionDbs)
            {
                Auction auction = _mapper.Map<Auction>(adb);
                result.Add(auction);
            }
            return result;
        }

        public List<Auction> GetAllActive(string userName)
        {
            var auctionDbs = _unitOfWork.Auctions.GetAllActive(userName);

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
            var auctionDbs = _unitOfWork.Auctions.GetAllByUserName(userName);

            List<Auction> result = new List<Auction>();
            foreach (AuctionDB adb in auctionDbs)
            {
                Auction auction = _mapper.Map<Auction>(adb);
                result.Add(auction);
            }
            return result;
        }

        public List<Auction> GetAllActiveByBidUserName(string userName)
        {
            var auctionDbs = _unitOfWork.Auctions.GetAllActiveByBidUserName(userName);

            List<Auction> result = new List<Auction>();
            foreach (AuctionDB adb in auctionDbs)
            {
                Auction auction = _mapper.Map<Auction>(adb);
                result.Add(auction);
            }
            return result;
        }

        public List<Auction> GetAllWonByUserName(string userName)
        {
            var auctionDbs = _unitOfWork.Auctions.GetAllWonByUserName(userName);

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
            var auctionDb = _unitOfWork.Auctions.GetById(id);

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
            _unitOfWork.Auctions.Add(adb);
            _unitOfWork.Commit();
        }

        public void Edit(int id, string description)
        {
            var adb = _unitOfWork.Auctions.Get(id);
            adb.Description = description;
            _unitOfWork.Commit();
        }

        public void Place(Bid bid)
        {
            BidDB bdb = _mapper.Map<BidDB>(bid);
            _unitOfWork.Bids.Add(bdb);
            _unitOfWork.Commit();
        }

        public void RemoveById(int id)
        {
            _unitOfWork.Auctions.Remove(_unitOfWork.Auctions.GetById(id));
            _unitOfWork.Commit();
        }

        public void CascadeByUserName(string userName)
        {
            IEnumerable<AuctionDB> auctions = _unitOfWork.Auctions.GetAllByUserName(userName);

            IEnumerable<AuctionDB> bidded_auctions = _unitOfWork.Auctions.GetAllActiveByBidUserName(userName);
            List<BidDB> bids = new();
            foreach(var auction in bidded_auctions)
            {
                foreach(var bid in auction.BidDBs)
                {
                    if(bid.UserName == userName)
                    {
                        bids.Add(bid);
                    }
                }
            }

            _unitOfWork.Bids.RemoveRange(bids);
            _unitOfWork.Auctions.RemoveRange(auctions);
            _unitOfWork.Commit();
        }
    }
}
