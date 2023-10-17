﻿namespace AuctionApplication.Core.Interfaces
{
    public interface IAuctionPersistence
    {
        List<Auction> GetAll();

        public Auction GetById(int id);

        void Add(Auction auction);
    }
}
