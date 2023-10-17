using Microsoft.EntityFrameworkCore;

namespace AuctionApplication.Persistence
{
    public class AuctionDbContext : DbContext
    {
        public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options) { }
    
        public DbSet<BidDB> BidDBs { get; set; }
        
        public DbSet<AuctionDB> AuctionDBs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuctionDB>().HasData(
                new AuctionDB
                {
                    Id = -1,
                    Name = "Test",
                    Description = "En test auktion",
                    UserName = "admin",
                    StartingPrice = 100,
                    ClosingTime = new DateTime(2023, 10, 17, 12, 0, 0)
                });
        }
    }
}
