using AuctionApplication.Core.Interfaces;
using Microsoft.AspNetCore.Server.IIS;

namespace AuctionApplication.Core
{
    public class AuctionService : IAuctionService
    {
        private IAuctionPersistence _auctionPersistence;

        public AuctionService(IAuctionPersistence auctionPersistence)
        {
            _auctionPersistence = auctionPersistence;
        }

        public List<Auction> GetAll()
        {
            return _auctionPersistence.GetAll();
        }

        public List<Auction> GetAllActive(string userName)
        {
            return _auctionPersistence.GetAllActive(userName);
        }

        public List<Auction> GetAllByUserName(string userName)
        {
            return _auctionPersistence.GetAllByUserName(userName);
        }

        public List<Auction> GetAllActiveByBidUserName(string userName)
        {
            return _auctionPersistence.GetAllActiveByBidUserName(userName);
        }

        public List<Auction> GetAllWonByUserName(string userName)
        {
            return _auctionPersistence.GetAllWonByUserName(userName);
        }

        public Auction GetById(int id)
        {
            return _auctionPersistence.GetById(id);
        }

        public void Add(Auction auction)
        {
            if (auction == null || auction.Id != 0) throw new InvalidDataException();
            _auctionPersistence.Add(auction);
        }

        public void Edit(int id, string description)
        {
            _auctionPersistence.Edit(id, description);
        }

        public ValidationResult Place(Bid bid)
        {
            Auction auction = GetById(bid.AuctionId);
            if (bid == null || bid.Id != 0 || bid.Price < 0) throw new InvalidDataException();

            ValidationResult result = new ValidationResult();

            if (!auction.Bids.Any())
            {
                if (bid.Price < auction.StartingPrice)
                {
                    result.SetError("Bid must be larger than starting price.");
                    return result;
                }
            }
            else
            {
                if (bid.Price <= auction.Bids.First().Price)
                {
                    result.SetError("Bid must be larger than highest bid.");
                    return result;
                }
            }

            if (auction.ClosingTime < DateTime.Now)
            {
                result.SetError("Unable to place bid. This auction has expired.");
                return result;
            }

            _auctionPersistence.Place(bid);
            return result;
        }

        public void RemoveById(int id)
        {
            _auctionPersistence.RemoveById(id);
        }

        public void CascadeByUserName(string userName)
        {
            _auctionPersistence.CascadeByUserName(userName);
        }
    }
}
