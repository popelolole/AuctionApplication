namespace AuctionApplication.Persistence.Interfaces
{
    public interface IUserUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        int Commit();
    }
}
