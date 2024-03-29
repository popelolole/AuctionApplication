﻿using AuctionApplication.Core;

namespace AuctionApplication.ViewModels
{
    public class AuctionVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public int StartingPrice { get; set; }
        public DateTime ClosingTime { get; set; }

        public static AuctionVM FromAuction(Auction auction)
        {
            AuctionVM auctionVM = new AuctionVM()
            {
                Id = auction.Id,
                Name = auction.Name,
                Description = auction.Description,
                UserName = auction.UserName,
                StartingPrice = auction.StartingPrice,
                ClosingTime = auction.ClosingTime
            };
            return auctionVM;
        }
    }
}
