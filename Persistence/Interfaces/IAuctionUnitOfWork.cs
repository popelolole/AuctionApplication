namespace AuctionApplication.Persistence.Interfaces
{
    public interface IAuctionUnitOfWork : IDisposable
    {
        IAuctionRepository Auctions { get; }
        IBidRepository Bids { get; }
        int Commit();
    }
}
