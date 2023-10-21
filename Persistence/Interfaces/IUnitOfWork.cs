namespace AuctionApplication.Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAuctionRepository Auctions { get; }
        IBidRepository Bids { get; }
        int Commit();
    }
}
