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
            AuctionDB adb = new AuctionDB()
            {
                Id = -1,
                Name = "Test",
                Description = "En test auktion",
                UserName = "pellebe@kth.se",
                StartingPrice = 100,
                ClosingTime = new DateTime(2023, 10, 17, 12, 0, 0)
            };

            modelBuilder.Entity<AuctionDB>().HasData(adb);

            BidDB bdb1 = new BidDB()
            {
                Id = -1,
                UserName = "pellebe@kth.se",
                Price = 500,
                CreatedDate = DateTime.Now,
                AuctionId = -1
            };

            BidDB bdb2 = new BidDB()
            {
                Id = -2,
                UserName = "pellebe@kth.se",
                Price = 1000,
                CreatedDate = DateTime.Now,
                AuctionId = -1
            };

            modelBuilder.Entity<BidDB>().HasData(bdb1);
            modelBuilder.Entity<BidDB>().HasData(bdb2);
        }
    }
}
